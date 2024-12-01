using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace ShoppingCart.Infrastructure.Utilities
{
    public interface IRedisService
    {
        IDatabase GetDatabase();
    }

    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConfiguration configuration)
        {
            _redis = ConnectionMultiplexer.Connect(configuration.GetSection("Redis")["ConnectionString"]);
        }

        public IDatabase GetDatabase()
        {
            return _redis.GetDatabase();
        }
    }
}
