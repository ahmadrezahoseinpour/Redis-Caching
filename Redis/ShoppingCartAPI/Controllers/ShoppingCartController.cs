using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Dtos;
using ShoppingCart.Business.Interfaces;
using ShoppingCart.Data.Models;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _cartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        // POST: api/ShoppingCart/{userId}/add
        [HttpPost("{userId}/add")]
        public async Task<IActionResult> AddToCart(string userId, [FromBody] CartItemDTO itemDto)
        {
            var item = _mapper.Map<CartItem>(itemDto);
            await _cartService.AddToCartAsync(userId, item);
            return Ok(new { message = "Item added to cart." });
        }

        // GET: api/ShoppingCart/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            var cartDto = _mapper.Map<List<CartItemDTO>>(cart);
            return Ok(cartDto);
        }

        // DELETE: api/ShoppingCart/{userId}/remove/{productId}
        [HttpDelete("{userId}/remove/{productId}")]
        public async Task<IActionResult> RemoveFromCart(string userId, string productId)
        {
            await _cartService.RemoveFromCartAsync(userId, productId);
            return Ok(new { message = "Item removed from cart." });
        }
    }
}
