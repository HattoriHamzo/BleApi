namespace BleApi.Dtos
{
    public class OrdersDTO
    {
        public int shipment_id;
        public int order_id;
        public string order_name;
        public DateTime order_date;
        public byte[]? order_image;
    }
}