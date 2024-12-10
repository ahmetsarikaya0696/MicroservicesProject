namespace Basket.API.Data
{
    public class BasketItem
    {
        public BasketItem(Guid id, string name, string? imageUrl, decimal price, decimal? discountAppliedPrice)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Price = price;
            DiscountAppliedPrice = discountAppliedPrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountAppliedPrice { get; set; }
    }
}
