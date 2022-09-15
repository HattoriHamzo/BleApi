using System.ComponentModel.DataAnnotations;

namespace BleApi.Products.Model
{
    public class Products
    {
        [Key]
        public int product_id {get; set;}
        public int product_category {get; set;}
        public string product_name {get; set;}
        public double product_price {get; set;}
        public int product_stock {get; set;}
        public byte[]? product_image {get; set;}
        public int provider_id {get; set;}
    }
}