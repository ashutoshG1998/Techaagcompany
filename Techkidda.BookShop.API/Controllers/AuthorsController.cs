using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techkidda.BookShop.API.DTOs;
using Techkidda.BookShop.API.Extension;
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

        [HttpGet]
        public async Task<ActionResult<List<AuthoreDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var querable= _context.authors.AsQueryable();
            await HttpContext.SetResponseHeader(querable);
            var author =await querable.OrderBy(x => x.Name).ToPaging(paginationDto).ToListAsync();
            return _mapper.Map<List<AuthoreDto>>(author);

        }
    }
}
