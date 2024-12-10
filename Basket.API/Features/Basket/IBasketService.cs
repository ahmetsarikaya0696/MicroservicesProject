namespace Basket.API.Features.Basket
{
    public interface IBasketService
    {
        Task<string?> GetBasketJsonFromCacheAsync(CancellationToken cancellationToken);
        Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken);
        Task CreateBasketCacheAsync(string basketAsJson, CancellationToken cancellationToken);
    }
}
