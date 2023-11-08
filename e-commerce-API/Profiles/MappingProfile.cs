using AutoMapper;
using e_commerce_API.Models;
using e_commerce_API.Data.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClientDto, Client>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni));
        CreateMap<EditClientDto, Client>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni));
        CreateMap<EditOrderStateDto, Order>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        CreateMap<AdminDto, Admin>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<SuperAdminDto, SuperAdmin>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.SizeClothes, opt => opt.MapFrom(src => src.SizeClothes))
            .ForMember(dest => dest.StyleClothes, opt => opt.MapFrom(src => src.StyleClothes))
            .ForMember(dest => dest.TypeClothes, opt => opt.MapFrom(src => src.TypeClothes));
    }
}
