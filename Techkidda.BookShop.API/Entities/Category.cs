using System.ComponentModel.DataAnnotations;

namespace Techkidda.BookShop.API.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
