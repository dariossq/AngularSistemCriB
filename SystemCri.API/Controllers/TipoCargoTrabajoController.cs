using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCargoTrabajoController : ControllerBase
    {
        private readonly ITipoCargoTrabajoRepository _repo;

        public TipoCargoTrabajoController(ITipoCargoTrabajoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCargoTrabajoResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new TipoCargoTrabajoResponseDto
            {
                Id = i.TicaCod,
                TicaNombre = i.TicaNombre,
                TicaDescrip = i.TicaDescrip
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCargoTrabajoResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new TipoCargoTrabajoResponseDto
            {
                Id = item.TicaCod,
                TicaNombre = item.TicaNombre,
                TicaDescrip = item.TicaDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<TipoCargoTrabajoResponseDto>> Post(TipoCargoTrabajoCreateDto dto)
        {
            var entity = new TipoCargoTrabajo
            {
                TicaNombre = dto.TicaNombre,
                TicaDescrip = dto.TicaDescrip
            };

            await _repo.AddAsync(entity);

            var response = new TipoCargoTrabajoResponseDto
            {
                Id = entity.TicaCod,
                TicaNombre = entity.TicaNombre,
                TicaDescrip = entity.TicaDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TipoCargoTrabajoUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TicaNombre = dto.TicaNombre;
            existing.TicaDescrip = dto.TicaDescrip;

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
