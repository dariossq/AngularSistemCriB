using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosController : ControllerBase
    {
        private readonly IAccesoRepository _accesoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AccesosController(IAccesoRepository accesoRepository, IUsuarioRepository usuarioRepository)
        {
            _accesoRepository = accesoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccesoResponseDto>>> GetAccesos()
        {
            var accesos = await _accesoRepository.GetAllAsync();
            var result = accesos.Select(a => new AccesoResponseDto
            {
                Id = a.CodAcceso,
                FechaIAcceso = a.FechaIAcceso,
                FechaFAcceso = a.FechaFAcceso,
                UsuarioId = a.UsuarioId
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccesoResponseDto>> GetAcceso(int id)
        {
            var acceso = await _accesoRepository.GetByIdAsync(id);
            if (acceso == null) return NotFound();

            var response = new AccesoResponseDto
            {
                Id = acceso.CodAcceso,
                FechaIAcceso = acceso.FechaIAcceso,
                FechaFAcceso = acceso.FechaFAcceso,
                UsuarioId = acceso.UsuarioId
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AccesoResponseDto>> PostAcceso(AccesoCreateDto dto)
        {
            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
                return BadRequest($"Usuario con id {dto.UsuarioId} no existe.");

            var acceso = new Acceso
            {
                FechaIAcceso = dto.FechaIAcceso,
                FechaFAcceso = dto.FechaFAcceso,
                UsuarioId = dto.UsuarioId
            };

            await _accesoRepository.AddAsync(acceso);

            var response = new AccesoResponseDto
            {
                Id = acceso.CodAcceso,
                FechaIAcceso = acceso.FechaIAcceso,
                FechaFAcceso = acceso.FechaFAcceso,
                UsuarioId = acceso.UsuarioId
            };

            return CreatedAtAction(nameof(GetAcceso), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(int id, AccesoUpdateDto dto)
        {
            var accesoExistente = await _accesoRepository.GetByIdAsync(id);
            if (accesoExistente == null) return NotFound();

            if (!await _usuarioRepository.ExistsAsync(dto.UsuarioId))
                return BadRequest($"Usuario con id {dto.UsuarioId} no existe.");

            accesoExistente.FechaIAcceso = dto.FechaIAcceso;
            accesoExistente.FechaFAcceso = dto.FechaFAcceso;
            accesoExistente.UsuarioId = dto.UsuarioId;

            await _accesoRepository.UpdateAsync(accesoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(int id)
        {
            var acceso = await _accesoRepository.GetByIdAsync(id);
            if (acceso == null) return NotFound();

            await _accesoRepository.DeleteAsync(acceso);
            return NoContent();
        }
    }
}
