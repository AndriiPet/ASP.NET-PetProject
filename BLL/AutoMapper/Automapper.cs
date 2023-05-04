using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System.Linq;

namespace BLL.AutoMapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<User, UserDto>()
              .ForMember(p => p.UserID, p2 => p2.MapFrom(src => src.UserID))
              .ReverseMap();

            CreateMap<Order, OrderDto>().
                ForMember(p => p.OrderID, p2 => p2.MapFrom(src => src.OrderID))
                .ReverseMap();
        }
    }
}
