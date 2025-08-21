using Microsoft.AspNetCore.Mvc;
using TicketIng.Api.Repositories;
using TicketIng.Models;

namespace TicketIng.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly CategoryRepository _repo;
        public CategorysController(CategoryRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category entity)
        {
            var id = await _repo.InsertAsync(entity);
            entity.Id = id;
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category entity)
        {
            if (id != entity.Id) return BadRequest();
            var updated = await _repo.UpdateAsync(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
