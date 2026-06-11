using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesinController : ControllerBase
    {
        private readonly IProfesinRepository _repo;

        public ProfesinController(IProfesinRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesinResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new ProfesinResponseDto
            {
                Id = i.ProfCod,
                ProfNombre = i.ProfNombre,
                ProfDescrip = i.ProfDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesinResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new ProfesinResponseDto
            {
                Id = item.ProfCod,
                ProfNombre = item.ProfNombre,
                ProfDescrip = item.ProfDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<ProfesinResponseDto>> Post(ProfesinCreateDto dto)
        {
            var entity = new Profesion
            {
                ProfNombre = dto.ProfNombre,
                ProfDescrip = dto.ProfDescrip
            };

            await _repo.AddAsync(entity);

            var response = new ProfesinResponseDto
            {
                Id = entity.ProfCod,
                ProfNombre = entity.ProfNombre,
                ProfDescrip = entity.ProfDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfesinUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.ProfNombre = dto.ProfNombre;
            existing.ProfDescrip = dto.ProfDescrip;

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
