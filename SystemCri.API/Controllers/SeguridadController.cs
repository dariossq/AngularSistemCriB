using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadRepository _seguridadRepository;

        public SeguridadController(ISeguridadRepository seguridadRepository)
        {
            _seguridadRepository = seguridadRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguridadResponseDto>>> GetSeguridads()
        {
            var seguridads = await _seguridadRepository.GetAllAsync();
            var result = seguridads.Select(s => new SeguridadResponseDto
            {
                Id = s.PerCod,
                PerCod = s.PerCod,
                SeguridadPer = s.SeguridadPer,
                SeguridadContra = s.SeguridadContra
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeguridadResponseDto>> GetSeguridad(int id)
        {
            var seguridad = await _seguridadRepository.GetByIdAsync(id);
            if (seguridad == null) return NotFound();

            var response = new SeguridadResponseDto
            {
                Id = seguridad.PerCod,
                PerCod = seguridad.PerCod,
                SeguridadPer = seguridad.SeguridadPer,
                SeguridadContra = seguridad.SeguridadContra
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<SeguridadResponseDto>> PostSeguridad(SeguridadCreateDto dto)
        {
            var seguridad = new Seguridad
            {
                PerCod = dto.PerCod ?? 0,
                SeguridadPer = dto.SeguridadPer,
                SeguridadContra = dto.SeguridadContra
            };

            await _seguridadRepository.AddAsync(seguridad);

            var response = new SeguridadResponseDto
            {
                Id = seguridad.PerCod,
                PerCod = seguridad.PerCod,
                SeguridadPer = seguridad.SeguridadPer,
                SeguridadContra = seguridad.SeguridadContra
            };

            return CreatedAtAction(nameof(GetSeguridad), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguridad(int id, SeguridadUpdateDto dto)
        {
            var existing = await _seguridadRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.SeguridadPer = dto.SeguridadPer;
            existing.SeguridadContra = dto.SeguridadContra;

            await _seguridadRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguridad(int id)
        {
            var seguridad = await _seguridadRepository.GetByIdAsync(id);
            if (seguridad == null) return NotFound();

            await _seguridadRepository.DeleteAsync(seguridad);
            return NoContent();
        }
    }
}
