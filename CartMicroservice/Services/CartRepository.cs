using CartMicroservice.Model;
using StackExchange.Redis;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartMicroservice.Services
{
    public class CartRepository
    {
        private readonly IDatabase _redisDb;

        public CartRepository(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        public async Task SaveCartAsync(string userId, Carts cart)
        {
            var json = JsonSerializer.Serialize(cart);
            await _redisDb.StringSetAsync(userId, json);
        }

        public async Task<Carts?> GetCartAsync(string userId)
        {
            var json = await _redisDb.StringGetAsync(userId);
            return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<Carts>(json);
        }

        public async Task DeleteCartAsync(string userId)
        {
            await _redisDb.KeyDeleteAsync(userId);
        }
    }

}
