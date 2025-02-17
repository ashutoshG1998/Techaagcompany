using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techkidda.BookShop.API.Services;

namespace Techkidda.BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IutilityService _IutilityService;

        public AuthorsController(ApplicationDbContext context, IMapper mapper, IutilityService utilityService)
        {
            _context = context;
            _mapper = mapper;
            _IutilityService = utilityService;
        }
    }
}
