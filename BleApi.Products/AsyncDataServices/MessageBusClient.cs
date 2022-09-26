using System.Text;
using System.Text.Json;
using BleApi.Products.Dtos;
using RabbitMQ.Client;

namespace BleApi.Products.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {

        private readonly IConfiguration configuration;
        private readonly IConnection connection;
        private readonly IModel channel;
        public MessageBusClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            var factory = new ConnectionFactory() { HostName = configuration["RabbitMQHost"], 
                Port = int.Parse(configuration["RabbitMQPort"])};
            try
            {
                connection = factory.CreateConnection();
                channel = connection.CreateModel();

                channel.ExchangeDeclare(exchange: "triggerMessage", type: ExchangeType.Fanout);

                Console.WriteLine("Connected to message bus");

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Could not connect to the message bus");
            }
        }
        public void PublishNewProduct(ProductsDTO productsDTO)
        {
            var message = JsonSerializer.Serialize(productsDTO);

            if (connection.IsOpen)
            {
                Console.WriteLine("RabbitMQ Connection open, sending message");
                SendMessage(message);
            }else
            {
                Console.WriteLine("RabbitMQ connections is closed, not sending");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "triggerMessage",
                                routingKey: "",
                                basicProperties: null,
                                body: body);
            Console.WriteLine($"We have sent {message}");
        }

        private void Dispose()
        {
            Console.WriteLine("MessageBus Disposed");
            if (channel.IsOpen)
            {
                channel.Close();
                connection.Close();
            }
        }

    }
}