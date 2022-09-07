using System.ComponentModel.DataAnnotations;

namespace BleApi.Dtos
{
    public class ProvidersDTO
    {
        [Key]
        public int provider_id {get; set;}
        public string? provider_name {get; set;}
        public string? provider_mail {get; set;}
        public string? provider_phone {get; set;}
        public int order_id {get; set;}
    }
}