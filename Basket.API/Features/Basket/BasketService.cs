using Basket.API.Consts;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Services;
using System.Text.Json;

namespace Basket.API.Features.Basket
{
    public class BasketService(IIdentityService identityService, IDistributedCache distributedCache) : IBasketService
    {
        private string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.UserId);

        public async Task<string?> GetBasketJsonFromCacheAsync(CancellationToken cancellationToken)
        {
            var cacheKey = GetCacheKey();
            var basketAsJson = await distributedCache.GetStringAsync(cacheKey, cancellationToken);
            return basketAsJson;
        }

        public async Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken)
        {
            var cacheKey = GetCacheKey();
            var basketAsJson = JsonSerializer.Serialize(basket);
            await distributedCache.SetStringAsync(cacheKey, basketAsJson, cancellationToken);
        }

        public async Task CreateBasketCacheAsync(string basketAsJson, CancellationToken cancellationToken)
        {
            var cacheKey = GetCacheKey();
            await distributedCache.SetStringAsync(cacheKey, basketAsJson, cancellationToken);
        }
    }
}
