using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SneakerStoreAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BCrypt.Net;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Web.Services3.Security.Utility;
using System.ComponentModel.DataAnnotations;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Check if user exists
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }

        // Verify password
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
        {
            return Unauthorized("Invalid password");
        }

        //  Get JWT secret key
        var secret = _config["JwtSettings:Secret"];
        if (string.IsNullOrEmpty(secret) || secret.Length < 32)
            throw new Exception("JWT Secret is missing or too short");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        // Create token descriptor
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
        }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        // Generate token
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        var client = new HttpClient();
        var googleResponse = await client.GetStringAsync(
            $"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={request.Token}"
        );

        var googleData = System.Text.Json.JsonDocument.Parse(googleResponse);
        var email = googleData.RootElement.GetProperty("email").GetString();

        if (string.IsNullOrEmpty(email))
            return BadRequest(new { success = false, message = "Invalid Google token" });

        // Check if user exists or create a new one
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()) // random pw
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Generate app JWT (same way as your normal login)
        var secret = _config["JwtSettings:Secret"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);

        return Ok(new { success = true, jwt });
    }

    public class GoogleLoginRequest
    {
        public string Token { get; set; }
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var errors = new List<string>();

        if (!ModelState.IsValid)
        {
            errors.AddRange(ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
        }

        if (_context.Users.Any(u => u.Email == request.Email))
            errors.Add("Email is already taken.");

        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            errors.Add("Password must be at least 6 characters long.");

        if (!request.Password.Any(char.IsUpper))
            errors.Add("Password must have at least one uppercase letter ('A'-'Z').");

        if (!request.Password.Any(char.IsDigit))
            errors.Add("Password must have at least one digit ('0'-'9').");

        if (!request.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            errors.Add("Password must have at least one non-alphanumeric character.");

        if (errors.Any())
            return BadRequest(new { success = false, errors });

        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { success = true, message = "User registered successfully" });
    }
}

    public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format (example@example.com)/")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }
}
