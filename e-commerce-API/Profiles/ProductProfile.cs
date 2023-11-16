using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.SizeClothes, opt => opt.MapFrom(src => src.SizeClothes))
                .ForMember(dest => dest.StyleClothes, opt => opt.MapFrom(src => src.StyleClothes))
                .ForMember(dest => dest.TypeClothes, opt => opt.MapFrom(src => src.TypeClothes));
            CreateMap<ProductPriceStockDto, Product>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UpdatePrice))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.UpdateStock));
        }
    }
}

