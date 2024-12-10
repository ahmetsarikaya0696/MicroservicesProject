using Basket.API.Features.Basket.Dtos;

namespace Basket.API.Features.Basket.GetBasket
{
    public record GetBasketQuery() : IRequest<ServiceResult<BasketDto>>;
}
