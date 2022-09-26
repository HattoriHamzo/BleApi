using System.Text.Json;
using BleApi.Categories.Dtos;
using AutoMapper;

namespace BleApi.Categories.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {

        private readonly IServiceScopeFactory scopeFactory;
        private readonly IMapper mapper;
        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            this.scopeFactory = scopeFactory;
            this.mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.ProductPublish:
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDTO>(notificationMessage);

            switch (eventType.Event)
            {
                case "Product_Publish":
                    Console.WriteLine("Product Publish Event Detected");
                    return EventType.ProductPublish;
                default:
                    Console.WriteLine("Could not determine the event type");
                    return EventType.Undertermined;
            }
        }

    }

    enum EventType
    {
        ProductPublish,
        Undertermined
    }
}