using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Interfaces
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync(string userId, CartItem item);
        Task<List<CartItem>> GetCartAsync(string userId);
        Task RemoveFromCartAsync(string userId, string productId);
    }
}
