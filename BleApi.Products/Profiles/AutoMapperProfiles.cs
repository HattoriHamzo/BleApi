using AutoMapper;
using BleApi.Products.Dtos;

namespace BleApi.Products.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Products, ProductsDTO>();
            CreateMap<ProductsDTO, Model.Products>();
        }
    }
}