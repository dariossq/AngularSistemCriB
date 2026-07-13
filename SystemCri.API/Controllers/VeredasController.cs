using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeredasController : ControllerBase
    {
        private readonly IVeredaRepository _veredaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public VeredasController(IVeredaRepository veredaRepository, IUsuarioRepository usuarioRepository)
        {
            _veredaRepository = veredaRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeredaResponseDto>>> GetVeredas()
        {
            var veredas = await _veredaRepository.GetAllAsync();
            var result = veredas.Select(v => new VeredaResponseDto
            {
                Id = v.VeredaCod,
                VeredaNom = v.VeredaNom,
                VeredaUbicacion = v.VeredaUbicacion,
                UsuarioId = v.UsuarioId
            });

            return Ok(result);
        }

        /// <summary>
        /// Obtiene todas las veredas asociadas a un usuario específico por su ID.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<VeredaResponseDto>>> GetVeredasByUsuarioId(int usuarioId)
        {
            var veredas = await _veredaRepository.GetByUsuarioIdAsync(usuarioId);
            var result = veredas.Select(v => new VeredaResponseDto
            {
                Id = v.VeredaCod,
                VeredaNom = v.VeredaNom,
                VeredaUbicacion = v.VeredaUbicacion,
                UsuarioId = v.UsuarioId
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeredaResponseDto>> GetVereda(int id)
        {
            var vereda = await _veredaRepository.GetByIdAsync(id);
            if (vereda == null) return NotFound();

            var response = new VeredaResponseDto
            {
                Id = vereda.VeredaCod,
                VeredaNom = vereda.VeredaNom,
                VeredaUbicacion = vereda.VeredaUbicacion,
                UsuarioId = vereda.UsuarioId
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<VeredaResponseDto>> PostVereda(VeredaCreateDto dto)
        {
            if (dto.UsuarioId.HasValue)
            {
                var usuarioExists = await _usuarioRepository.ExistsAsync(dto.UsuarioId.Value);
                if (!usuarioExists) return BadRequest($"Usuario con id {dto.UsuarioId.Value} no existe.");
            }

            var vereda = new Vereda
            {
                VeredaNom = dto.VeredaNom,
                VeredaUbicacion = dto.VeredaUbicacion,
                UsuarioId = dto.UsuarioId
            };

            await _veredaRepository.AddAsync(vereda);

            var response = new VeredaResponseDto
            {
                Id = vereda.VeredaCod,
                VeredaNom = vereda.VeredaNom,
                VeredaUbicacion = vereda.VeredaUbicacion,
                UsuarioId = vereda.UsuarioId
            };

            return CreatedAtAction(nameof(GetVereda), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVereda(int id, VeredaUpdateDto dto)
        {
            // Validar que la vereda existe
            if (!await _veredaRepository.ExistsAsync(id))
                return NotFound();

            if (dto.UsuarioId.HasValue)
            {
                var usuarioExists = await _usuarioRepository.ExistsAsync(dto.UsuarioId.Value);
                if (!usuarioExists) return BadRequest($"Usuario con id {dto.UsuarioId.Value} no existe.");
            }

            // Crear objeto para actualizar
            var vereda = new Vereda
            {
                VeredaCod = id,
                VeredaNom = dto.VeredaNom,
                VeredaUbicacion = dto.VeredaUbicacion,
                UsuarioId = dto.UsuarioId
            };

            await _veredaRepository.UpdateAsync(vereda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVereda(int id)
        {
            var vereda = await _veredaRepository.GetByIdAsync(id);
            if (vereda == null) return NotFound();

            await _veredaRepository.DeleteAsync(vereda);
            return NoContent();
        }
    }
}
