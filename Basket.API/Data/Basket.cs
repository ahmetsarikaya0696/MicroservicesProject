using System.Text.Json.Serialization;

namespace Basket.API.Data
{
    public class Basket
    {
        public Guid UserId { get; set; }

        public List<BasketItem> BasketItems { get; set; } = [];
        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }

        [JsonIgnore]
        public decimal TotalPrice => BasketItems.Sum(x => x.Price);

        [JsonIgnore]
        public bool IsDiscountApplied => DiscountRate > 0 && Coupon is not null;

        [JsonIgnore]
        public decimal? DiscountAppliedTotalPrice => IsDiscountApplied ? TotalPrice * (1 - (decimal)DiscountRate!) : null;

        public Basket(Guid userId, List<BasketItem> basketItems)
        {
            UserId = userId;
            BasketItems = basketItems;
        }

        public void ApplyNewDiscount(string coupon, float discountRate)
        {
            Coupon = coupon;
            DiscountRate = discountRate;

            foreach (var basketItem in BasketItems)
            {
                basketItem.DiscountAppliedPrice = basketItem.Price * (decimal)(1 - discountRate);
            }
        }

        public void ApplyCurrentDiscount()
        {
            if (!IsDiscountApplied) return;

            foreach (var basketItem in BasketItems)
            {
                basketItem.DiscountAppliedPrice = basketItem.Price * (decimal)(1 - DiscountRate!);
            }
        }

        public void ClearDiscount()
        {
            DiscountRate = null;
            Coupon = null;

            foreach (var basketItem in BasketItems)
            {
                basketItem.DiscountAppliedPrice = null;
            }
        }
    }
}
