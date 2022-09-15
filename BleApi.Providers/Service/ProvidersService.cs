using BleApi.Providers.Dtos;
using BleApi.Providers.Interfaces;
using BleApi.Providers.Context;
using BleApi.Providers.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BleApi.Providers.Service
{
    class ProvidersService : IProvidersService
    {
        private readonly ProvidersDbContext dbContext;
        private readonly ILogger<ProvidersService> logger;
        private readonly IMapper mapper;


        public ProvidersService(ProvidersDbContext dbContext, ILogger<ProvidersService> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)> GetAllProvidersAsync()
        {
            try
            {
                var allProviders = await dbContext.Providers.ToListAsync();

                if (allProviders != null && allProviders.Any())
                {
                    var mappedProviders = mapper.Map<IEnumerable<BleApi.Providers.Model.Providers>, IEnumerable<ProvidersDTO>>(allProviders);

                    return (true, mappedProviders, "");
                }
                return (false, null, "You don't have any providers at the moment, providers not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)> GetProvidersByIdAsync(int id)
        {
            try
            {
                var providerById = await dbContext.Providers.FirstOrDefaultAsync(providers => providers.provider_id == id );

                if (providerById != null)
                {
                    var mappedProvider = mapper.Map<BleApi.Providers.Model.Providers, ProvidersDTO>(providerById);

                    return(true, mappedProvider, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)> GetProvidersByNameAsync(string name)
        {
            try
            {
                var searchByName = dbContext.Providers.Where(provider => provider.provider_name.Contains(name));
                var providerByName = await searchByName.ToListAsync();

                if (providerByName != null)
                {
                    var mappedProvider = mapper.Map<IEnumerable<BleApi.Providers.Model.Providers>, IEnumerable<ProvidersDTO>>(providerByName);
                    return(true, mappedProvider, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string statusMessage)> CreateProviderAsync(ProvidersDTO provider)
        {
            try
            {
                var searchIfExists = dbContext.Providers.Any(providersEntity => providersEntity.provider_id == provider.provider_id);

                if (!searchIfExists)
                {
                    var mappedProviders = mapper.Map<BleApi.Providers.Model.Providers>(provider);
                        dbContext.Providers.Add(mappedProviders);
                        await dbContext.SaveChangesAsync();
                    return(true, "Provider Created");
                }

                return(false, "Provider Not Created");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, ex.Message);
            }
        }
    }
}