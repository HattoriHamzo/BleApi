using System.ComponentModel.DataAnnotations;

namespace BleApi.Categories.Dtos
{
    public class CategoriesDTO
    {
        [Key]
        public int category_id {get; set;}
        [Required]
        public string category_name {get; set;}

    }
}