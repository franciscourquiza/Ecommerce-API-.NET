using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Profiles
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminDto, Admin>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<EditAdminSuperAdminDto, Admin>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
