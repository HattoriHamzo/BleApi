using AutoMapper;
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

            CreateMap<ProductsDTO, Model.Products>();
            CreateMap<ProvidersDTO, Model.Providers>();
            CreateMap<OrdersDTO, Model.Orders>();
        }
    }
}