using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadController : ControllerBase
    {
        private readonly IEscolaridadRepository _repo;

        public EscolaridadController(IEscolaridadRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscolaridadResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new EscolaridadResponseDto
            {
                Id = i.EscolaridadCod,
                EscolaridadNom = i.EscolaridadNom,
                EscolaridadDescrip = i.EscolaridadDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EscolaridadResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new EscolaridadResponseDto
            {
                Id = item.EscolaridadCod,
                EscolaridadNom = item.EscolaridadNom,
                EscolaridadDescrip = item.EscolaridadDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<EscolaridadResponseDto>> Post(EscolaridadCreateDto dto)
        {
            var entity = new Escolaridad
            {
                EscolaridadNom = dto.EscolaridadNom,
                EscolaridadDescrip = dto.EscolaridadDescrip
            };

            await _repo.AddAsync(entity);

            var response = new EscolaridadResponseDto
            {
                Id = entity.EscolaridadCod,
                EscolaridadNom = entity.EscolaridadNom,
                EscolaridadDescrip = entity.EscolaridadDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EscolaridadUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.EscolaridadNom = dto.EscolaridadNom;
            existing.EscolaridadDescrip = dto.EscolaridadDescrip;

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
