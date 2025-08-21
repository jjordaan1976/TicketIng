using Microsoft.AspNetCore.Mvc;
using TicketIng.Api.Repositories;
using TicketIng.Models;

namespace TicketIng.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleRepository _repo;
        public RolesController(RoleRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(Role entity)
        {
            var id = await _repo.InsertAsync(entity);
            entity.Id = id;
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role entity)
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
