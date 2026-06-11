using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdController : ControllerBase
    {
        private readonly ITipoIdRepository _repo;

        public TipoIdController(ITipoIdRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIdResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new TipoIdResponseDto
            {
                Id = i.TipoIdCod,
                TipoIdNom = i.TipoIdNom,
                TipoIdSigla = i.TipoIdSigla
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new TipoIdResponseDto
            {
                Id = item.TipoIdCod,
                TipoIdNom = item.TipoIdNom,
                TipoIdSigla = item.TipoIdSigla
            });
        }

        [HttpPost]
        public async Task<ActionResult<TipoIdResponseDto>> Post(TipoIdCreateDto dto)
        {
            var entity = new TipoId
            {
                TipoIdNom = dto.TipoIdNom,
                TipoIdSigla = dto.TipoIdSigla
            };

            await _repo.AddAsync(entity);

            var response = new TipoIdResponseDto
            {
                Id = entity.TipoIdCod,
                TipoIdNom = entity.TipoIdNom,
                TipoIdSigla = entity.TipoIdSigla
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TipoIdUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TipoIdNom = dto.TipoIdNom;
            existing.TipoIdSigla = dto.TipoIdSigla;

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
