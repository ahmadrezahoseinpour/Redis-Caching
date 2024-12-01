using ShoppingCart.Business.Interfaces;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ICartRepository _cartRepository;

        public ShoppingCartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(string userId, CartItem item)
        {
            await _cartRepository.AddToCartAsync(userId, item);
        }

        public async Task<List<CartItem>> GetCartAsync(string userId)
        {
            return await _cartRepository.GetCartAsync(userId);
        }

        public async Task RemoveFromCartAsync(string userId, string productId)
        {
            await _cartRepository.RemoveFromCartAsync(userId, productId);
        }
    }
}
