using BleApi.Categories.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BleApi.Categories.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void ReceiveProductCreatedQueueMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" , Port = 8087 };
            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("product", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArgs) => {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Product message received: {message}");
            };
            //read the message
            channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
            Console.ReadKey();
        }
    }
}