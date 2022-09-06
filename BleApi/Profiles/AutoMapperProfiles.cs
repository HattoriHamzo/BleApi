using AutoMapper;
using BleApi.Model;
using BleApi.Dtos;

namespace BleApi.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Products, ProductsDTO>();
            CreateMap<Model.Providers, ProvidersDTO>();
            CreateMap<Model.Orders, OrdersDTO>();
        }
    }
}