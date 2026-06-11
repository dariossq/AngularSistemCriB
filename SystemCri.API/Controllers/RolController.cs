using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _repo;

        public RolController(IRolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new RolResponseDto
            {
                Id = i.RolCod,
                RolNom = i.RolNom,
                RolDescrip = i.RolDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new RolResponseDto
            {
                Id = item.RolCod,
                RolNom = item.RolNom,
                RolDescrip = item.RolDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<RolResponseDto>> Post(RolCreateDto dto)
        {
            var entity = new Rol
            {
                RolNom = dto.RolNom,
                RolDescrip = dto.RolDescrip
            };

            await _repo.AddAsync(entity);

            var response = new RolResponseDto
            {
                Id = entity.RolCod,
                RolNom = entity.RolNom,
                RolDescrip = entity.RolDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RolUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.RolNom = dto.RolNom;
            existing.RolDescrip = dto.RolDescrip;

            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}
