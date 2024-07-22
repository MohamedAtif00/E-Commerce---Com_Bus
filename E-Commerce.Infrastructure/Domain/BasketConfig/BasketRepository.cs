using E_Commerce.Domain.Model.BasketAggre;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.BasketConfig
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<Basket> GetBasketAsync(Guid id)
        {
            var db = _redis.GetDatabase();
            var data = await db.StringGetAsync(id.ToString());
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(data);
        }

        public async Task AddBasketAsync(Basket basket)
        {
            var db = _redis.GetDatabase();
            var data = JsonSerializer.Serialize(basket);
            await db.StringSetAsync(basket.Id.ToString(), data);
        }

        public async Task RemoveBasketAsync(Guid id)
        {
            var db = _redis.GetDatabase();
            await db.KeyDeleteAsync(id.ToString());
        }

        public async Task UpdateBasketAsync(Basket basket)
        {
            var db = _redis.GetDatabase();
            var data = JsonSerializer.Serialize(basket);
            await db.StringSetAsync(basket.Id.ToString(), data);
        }
    }
}
