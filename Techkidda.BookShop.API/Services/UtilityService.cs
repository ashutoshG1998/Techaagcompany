
namespace Techkidda.BookShop.API.Services
{
    public class UtilityService : IutilityService
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityService(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }
        public Task deleteImage(string ContainerName, string dbpath)
        {
            if (string.IsNullOrEmpty(dbpath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbpath);
            var completepath = Path.Combine(_env.WebRootPath, ContainerName, filename);
            if (File.Exists(completepath))
            {
                File.Delete(completepath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbpath)
        {
            await deleteImage(ContainerName, dbpath);
            return await SaveImage(ContainerName, file);
        }

        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, ContainerName);

            // Create the directory if it does not exist
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filepath = Path.Combine(folder, filename);
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(filepath, content);
            }

            var basepath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var completepath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");
            return completepath;
        }
    }
}
