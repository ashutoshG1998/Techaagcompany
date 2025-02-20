using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techkidda.BookShop.API.DTOs;
using Techkidda.BookShop.API.Entities;

namespace Techkidda.BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            var categories = await _context.Categories.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CategoryDTO>> Get(int Id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoryDTO>(category);

        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] CategoryCreationDTO categoryCreationDTO)
        {
            var category = _mapper.Map<Category>(categoryCreationDTO);

            _context.Categories.Add(category);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id, [FromBody] CategoryCreationDTO categoryCreationDTO)
        {
            var category = _mapper.Map<Category>(categoryCreationDTO);
            category.Id = id;
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id, [FromBody] CategoryCreationDTO categoryCreationDTO)
        {
            //var category = _mapper.Map<Category>(categoryCreationDTO);
            //category.Id = id;
            //_context.Entry(category).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return NoContent();
            var category=await _context.Categories.FirstOrDefaultAsync(x=>x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
