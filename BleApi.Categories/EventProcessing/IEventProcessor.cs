namespace BleApi.Categories.EventProcessing
{
    public interface IEventProcessor
    {
        public void ProcessEvent(string message);
    }
}