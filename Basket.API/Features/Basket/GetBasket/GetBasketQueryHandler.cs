using AutoMapper;
using Basket.API.Features.Basket.Dtos;
using System.Net;
using System.Text.Json;

namespace Basket.API.Features.Basket.GetBasket
{
    public class GetBasketQueryHandler(IBasketService basketService, IMapper mapper) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketJsonFromCacheAsync(cancellationToken);
            if (string.IsNullOrEmpty(basketAsJson)) return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            var mappedBasket = mapper.Map<BasketDto>(basket);

            return ServiceResult<BasketDto>.SuccessAsOk(mappedBasket);
        }
    }
}
