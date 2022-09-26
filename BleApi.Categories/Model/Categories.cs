using System.ComponentModel.DataAnnotations;

namespace BleApi.Categories.Model
{
    public class Categories
    {
        [Key]
        public int category_id {get; set;}
        [Required]
        public string category_name {get; set;}

    }
}