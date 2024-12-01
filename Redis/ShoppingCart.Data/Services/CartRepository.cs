using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Infrastructure.Utilities;

namespace ShoppingCart.Data.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly IRedisService _redisService;
        private readonly IDatabase _db;

        public CartRepository(IRedisService redisService)
        {
            _redisService = redisService;
            _db = _redisService.GetDatabase();
        }

        private string GetCartKey(string userId) => $"cart:{userId}";

        public async Task AddToCartAsync(string userId, CartItem item)
        {
            string cartKey = GetCartKey(userId);
            string itemJson = JsonSerializer.Serialize(item);
            await _db.HashSetAsync(cartKey, item.ProductId, itemJson);
            await _db.KeyExpireAsync(cartKey, TimeSpan.FromHours(24)); // Optional expiration
        }

        public async Task<List<CartItem>> GetCartAsync(string userId)
        {
            string cartKey = GetCartKey(userId);
            var entries = await _db.HashGetAllAsync(cartKey);
            return entries.Select(entry => JsonSerializer.Deserialize<CartItem>(entry.Value)).ToList();
        }

        public async Task RemoveFromCartAsync(string userId, string productId)
        {
            string cartKey = GetCartKey(userId);
            await _db.HashDeleteAsync(cartKey, productId);
        }
    }
}
