namespace Basket.API.Features.Basket.Dtos
{
    /// <summary>
    /// Basket item is a course
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="ImageUrl"></param>
    /// <param name="Price"></param>
    /// <param name="DiscountAppliedPrice"></param>
    public record BasketItemDto(
        Guid Id,
        string Name,
        string? ImageUrl,
        decimal Price,
        decimal? DiscountAppliedPrice = null);
}
