namespace Basket.API.Features.Basket.AddBasketItem
{
    public record AddBasketItemCommand(
        Guid CourseId,
        string CourseName,
        decimal CoursePrice,
        string? CourseImageUrl) : IRequest<ServiceResult>;
}
