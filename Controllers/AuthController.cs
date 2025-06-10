using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace SneakerStoreAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

    }
}
