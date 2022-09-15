using BleApi.Providers.Dtos;

namespace BleApi.Providers.Interfaces
{
    public interface IProvidersService
    {
        /*--- GET METHODS ---*/
        Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)>GetAllProvidersAsync();
        Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)>GetProvidersByIdAsync(int id);
        Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)>GetProvidersByNameAsync(string name);

        /*--- POST METHODS ---*/
        Task<(bool isSuccess, string statusMessage)>CreateProviderAsync(ProvidersDTO order);

    }
}