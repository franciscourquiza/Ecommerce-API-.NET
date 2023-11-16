using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<EditOrderStateDto, Order>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        }
    }
}
