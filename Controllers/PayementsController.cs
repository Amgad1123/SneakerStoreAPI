using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using SneakerStoreAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    [HttpPost("create-checkout-session")]
    public ActionResult CreateCheckoutSession([FromBody] CheckoutRequest request)
    {
        StripeConfiguration.ApiKey = "sk_test_51SP5fgF54DIZqIei13u6ueDllkyxZwkJamqZWqWgY2PcEH2IUhpElo8uOLRPCWbmShfirctwVavudU4o8Mprqb5b00F0ALT6In";

        var domain = "http://localhost:3000"; // frontend URL

        var lineItems = request.Items.Select(item => new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                Currency = "usd",
                UnitAmount = (long)(item.Price * 100), // convert dollars to cents
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = item.Name,
                },
            },
            Quantity = item.Quantity,
        }).ToList();

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = lineItems,
            Mode = "payment",
            SuccessUrl = domain + "/success",
            CancelUrl = domain + "/cancel",
        };

        var service = new SessionService();
        var session = service.Create(options);

        return Ok(new { url = session.Url }); // Send the redirect URL to the frontend
    }
}

public class CheckoutRequest
{
    public List<CartItemDto> Items { get; set; }
}

public class CartItemDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}