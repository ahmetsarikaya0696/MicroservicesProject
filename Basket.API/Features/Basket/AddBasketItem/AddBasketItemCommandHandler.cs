using Basket.API.Data;
using Shared.Services;
using System.Text.Json;

namespace Basket.API.Features.Basket.AddBasketItem
{
    public class AddBasketItemCommandHandler(IIdentityService identityService, IBasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketJsonFromCacheAsync(cancellationToken);

            var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.CourseImageUrl, request.CoursePrice, null);

            Data.Basket? currentBasket;
            if (string.IsNullOrEmpty(basketAsJson))
            {
                currentBasket = new Data.Basket(identityService.UserId, [newBasketItem]);
            }
            else
            {
                currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

                var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);
                if (existingBasketItem is not null) currentBasket.BasketItems.Remove(existingBasketItem);

                currentBasket.BasketItems.Add(newBasketItem);
            }

            currentBasket.ApplyCurrentDiscount();

            await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
