using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techkidda.BookShop.API.DTOs;
using Techkidda.BookShop.API.Entities;
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
        private readonly string Containername = "AuthoreName";

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
        [HttpPost("searchByName")]
        public async Task<ActionResult<List<AuthorBookDto>>> SearchbyName([FromBody]string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
            { return new List<AuthorBookDto>(); }

            return await _context.authors.Where(x => x.Name.Contains(name)).OrderBy(x => x.Name).Select(C => new AuthorBookDto
            {
                Id = C.Id,
                Name = C.Name,
                Picture = C.picture
            }).Take(10).ToListAsync();    
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthoreDto>> Get(int id)
        {
            var author=await _context.authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return _mapper.Map<AuthoreDto>(author);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AuthoreCreationDto authoreCreationDto)
        {
            var authore = _mapper.Map<Author>(authoreCreationDto);
            if(authoreCreationDto.picture!=null)
            {
                authore.picture = await _IutilityService.SaveImage(Containername, authoreCreationDto.picture);
            }
            _context.authors.Add(authore);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] AuthoreCreationDto authoreCreationDto)
        {
            var authore=await _context.authors.FirstOrDefaultAsync(x=>x.Id == id);
            if (authore == null)
            {
                return NotFound();
            }
            authore = _mapper.Map(authoreCreationDto, authore);
            if(authoreCreationDto.picture!=null)
            {
                authore.picture = await _IutilityService.EditImage(Containername, authoreCreationDto.picture, authore.picture);
               
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var authore= await _context.authors.FirstOrDefaultAsync(x => x.Id == Id);
            if(authore == null)
            {  return NotFound(); }
            await _IutilityService.deleteImage(Containername, authore.picture);
            _context.Remove(authore);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
