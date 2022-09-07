using System.ComponentModel.DataAnnotations;

namespace BleApi.Dtos
{
    public class OrdersDTO
    {
        [Key]
        public int order_id {get; set;}
        public string order_name {get; set;}
        public DateTime order_date {get; set;}
        public byte[]? order_image {get; set;}
    }
}