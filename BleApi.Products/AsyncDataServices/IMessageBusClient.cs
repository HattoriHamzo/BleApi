using BleApi.Products.Dtos;

namespace BleApi.Products.AsyncDataServices
{
    public interface IMessageBusClient
    {
        public void PublishNewProduct(ProductsDTO productsDTO);
    }
}