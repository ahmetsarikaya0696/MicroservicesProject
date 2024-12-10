using System.Text.Json.Serialization;

namespace Basket.API.Features.Basket.Dtos
{
    public record BasketDto
    {
        public List<BasketItemDto> BasketItems { get; init; }

        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }

        [JsonIgnore]
        public bool IsDiscountApplied => DiscountRate > 0 && Coupon is not null;

        public decimal TotalPrice => BasketItems.Sum(x => x.Price);
        public decimal? DiscountAppliedTotalPrice => IsDiscountApplied ? TotalPrice * (1 - (decimal)DiscountRate!) : null;

        public BasketDto(List<BasketItemDto> basketItems)
        {
            BasketItems = basketItems;
        }
    }
}
