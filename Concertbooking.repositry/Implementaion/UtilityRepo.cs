using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.Concertbooking.repositry
{
    public class UtilityRepo : IutilityRepo
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _ContextAccessor;

        public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _ContextAccessor = contextAccessor;
        }

        //https://localhost:5001/containerName-sdff21-dfdf4-as54a.jpg
        public Task deleteImage(string ContainerName, string dbpath)
        {
           if(string.IsNullOrEmpty(dbpath))
            {
                return Task.CompletedTask;
            }
            var filename=Path.GetFileName(dbpath);
             var completepath=Path.Combine(_env.WebRootPath,ContainerName,filename);
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
        //Guid.newguid() //df4d-df55-sda4.jpg
        //https://localhost:7182/ContainerName/df4d-df55-sda4.jpg
        //public async Task<string> SaveImage(string ContainerName, IFormFile file)
        //{
        //    var extension = Path.GetExtension(file.FileName);
        //    var filename = $"{Guid.NewGuid()}{extension}";
        //    string folder = Path.Combine(_env.WebRootPath, ContainerName);
        //    if (Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);

        //    }
        //    string filepath = Path.Combine(folder, filename);
        //    using (var meomeryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(meomeryStream);
        //        var content = meomeryStream.ToArray();
        //        await File.WriteAllBytesAsync(filepath, content);
        //    }
        //    var basepath = $"{_ContextAccessor.HttpContext.Request.Scheme}://{_ContextAccessor.HttpContext.Request.Host}";
        //    var completepath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");
        //    return completepath;
        //}
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

            var basepath = $"{_ContextAccessor.HttpContext.Request.Scheme}://{_ContextAccessor.HttpContext.Request.Host}";
            var completepath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");
            return completepath;
        }

    }
}
