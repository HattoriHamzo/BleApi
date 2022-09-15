using AutoMapper;
using BleApi.Categories.Dtos;
namespace BleApi.Categories.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BleApi.Categories.Model.Categories, CategoriesDTO>();
            CreateMap<CategoriesDTO, BleApi.Categories.Model.Categories>();
        }
    }
}