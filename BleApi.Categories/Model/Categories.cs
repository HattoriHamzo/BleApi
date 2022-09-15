using System.ComponentModel.DataAnnotations;

namespace BleApi.Categories.Model
{
    public class Categories
    {
        [Key]
        public int category_id {get; set;}
        public string category_name {get; set;}
        public int product_id {get; set;}
    }
}