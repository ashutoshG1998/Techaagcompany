using System.ComponentModel.DataAnnotations;

namespace Techkidda.BookShop.API.DTOs
{
    public class AuthoreDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Authore Name Required")]
        public string Name { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? BioGraphy { get; set; }
        public string? picture { get; set; }
    }
}
