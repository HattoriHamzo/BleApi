namespace BleApi.Categories.Interfaces
{
    public interface IRabitMQProducer
    {
        public void ReceiveProductCreatedQueueMessage();
    }
}