using AutoMapper;
using Basket.API.Data;
using Basket.API.Features.Basket.Dtos;

namespace Basket.API.Features.Basket
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketDto, Data.Basket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
        }
    }
}
