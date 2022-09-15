using AutoMapper;
using BleApi.Orders.Dtos;

namespace BleApi.Orders.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BleApi.Orders.Model.Orders, OrdersDTO>();
            CreateMap<OrdersDTO, BleApi.Orders.Model.Orders>();
        }
    }
}
