using Microsoft.AspNetCore.Mvc;
using SneakerStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    // In-memory cart storage
    private static List<CartItemDto> Cart = new List<CartItemDto>();

    // Get all items in the cart
    [HttpGet]
    public IActionResult GetCartItems()
    {
        return Ok(Cart);
    }

    // Add item to cart
    [HttpPost]
    public IActionResult AddToCart([FromBody] CartItemDto item)
    {
        if (item == null)
            return BadRequest("Item cannot be null");

        var existing = Cart.FirstOrDefault(i => i.Name == item.Name);

        if (existing != null)
        {
            existing.Quantity += item.Quantity;
        }
        else
        {
            Cart.Add(item);
        }

        return Ok(Cart);
    }

    // Update quantity or price of a specific item
    [HttpPut("{name}")]
    public IActionResult UpdateCartItem(string name, [FromBody] CartItemDto updatedItem)
    {
        var item = Cart.FirstOrDefault(i => i.Name == name);
        if (item == null)
            return NotFound();

        item.Quantity = updatedItem.Quantity;
        item.Price = updatedItem.Price;
        item.ImageUrl = updatedItem.ImageUrl; // ✅ Make sure image is updated too

        return Ok(Cart);
    }

    // Remove item from cart
    [HttpDelete("{name}")]
    public IActionResult RemoveItem(string name)
    {
        var item = Cart.FirstOrDefault(i => i.Name == name);
        if (item == null)
            return NotFound();

        Cart.Remove(item);
        return Ok(Cart);
    }
}

