using AutoMapper;
using BleApi.Providers.Dtos;

namespace BleApi.Providers.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Providers, ProvidersDTO>();
            CreateMap<ProvidersDTO, Model.Providers>();
        }
    }
}