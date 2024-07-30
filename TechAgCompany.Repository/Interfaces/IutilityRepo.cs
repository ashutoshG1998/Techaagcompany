using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Repository.Interfaces
{
    public  interface IutilityRepo
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file,string dbpath);

        Task deleteImage(string ContainerName,string dbpath);
        
    }
}
