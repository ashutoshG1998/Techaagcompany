namespace Techkidda.BookShop.API.DTOs
{
    public class AuthoreCreationDto
    {
        public  required string Name { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? BioGraphy { get; set; }
        public IFormFile? picture { get; set; }
    }
}
