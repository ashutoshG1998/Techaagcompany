namespace Techkidda.BookShop.API.Services
{
    public interface IutilityService
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file, string dbpath);

        Task deleteImage(string ContainerName, string dbpath);
    }
}
