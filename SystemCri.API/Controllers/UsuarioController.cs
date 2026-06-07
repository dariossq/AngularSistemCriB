using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDeptoRepository _deptoRepository;
        private readonly IMunicipioRepository _municipioRepository;

        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IDeptoRepository deptoRepository,
            IMunicipioRepository municipioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _deptoRepository = deptoRepository;
            _municipioRepository = municipioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var result = usuarios.Select(u => new UsuarioResponseDto
            {
                Id = u.UsuarioId,
                UsuarioNombre = u.UsuarioNombre,
                UsuarioDescripcion = u.UsuarioDescripcion,
                UsuarioLogo = u.UsuarioLogo,
                UsuarioPie = u.UsuarioPie,
                UsuarioEtnia = u.UsuarioEtnia,
                UsuarioDepartamento = u.UsuarioDepartamento,
                UsuarioMunicipio = u.UsuarioMunicipio,
                UsuarioEstado = u.UsuarioEstado
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var response = new UsuarioResponseDto
            {
                Id = usuario.UsuarioId,
                UsuarioNombre = usuario.UsuarioNombre,
                UsuarioDescripcion = usuario.UsuarioDescripcion,
                UsuarioLogo = usuario.UsuarioLogo,
                UsuarioPie = usuario.UsuarioPie,
                UsuarioEtnia = usuario.UsuarioEtnia,
                UsuarioDepartamento = usuario.UsuarioDepartamento,
                UsuarioMunicipio = usuario.UsuarioMunicipio,
                UsuarioEstado = usuario.UsuarioEstado
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDto>> PostUsuario(UsuarioCreateDto dto)
        {
            if (dto.UsuarioDepartamento.HasValue)
            {
                var deptoExists = await _deptoRepository.ExistsAsync(dto.UsuarioDepartamento.Value);
                if (!deptoExists) return BadRequest($"Departamento con id {dto.UsuarioDepartamento.Value} no existe.");
            }

            if (dto.UsuarioMunicipio.HasValue)
            {
                var municipioExists = await _municipioRepository.ExistsAsync(dto.UsuarioMunicipio.Value);
                if (!municipioExists) return BadRequest($"Municipio con id {dto.UsuarioMunicipio.Value} no existe.");
            }

            var usuario = new Usuario
            {
                UsuarioNombre = dto.UsuarioNombre,
                UsuarioDescripcion = dto.UsuarioDescripcion,
                UsuarioLogo = dto.UsuarioLogo,
                UsuarioPie = dto.UsuarioPie,
                UsuarioEtnia = dto.UsuarioEtnia,
                UsuarioDepartamento = dto.UsuarioDepartamento,
                UsuarioMunicipio = dto.UsuarioMunicipio,
                UsuarioEstado = dto.UsuarioEstado
            };

            await _usuarioRepository.AddAsync(usuario);

            var response = new UsuarioResponseDto
            {
                Id = usuario.UsuarioId,
                UsuarioNombre = usuario.UsuarioNombre,
                UsuarioDescripcion = usuario.UsuarioDescripcion,
                UsuarioLogo = usuario.UsuarioLogo,
                UsuarioPie = usuario.UsuarioPie,
                UsuarioEtnia = usuario.UsuarioEtnia,
                UsuarioDepartamento = usuario.UsuarioDepartamento,
                UsuarioMunicipio = usuario.UsuarioMunicipio,
                UsuarioEstado = usuario.UsuarioEstado
            };

            return CreatedAtAction(nameof(GetUsuario), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDto dto)
        {
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null) return NotFound();

            if (dto.UsuarioDepartamento.HasValue)
            {
                var deptoExists = await _deptoRepository.ExistsAsync(dto.UsuarioDepartamento.Value);
                if (!deptoExists) return BadRequest($"Departamento con id {dto.UsuarioDepartamento.Value} no existe.");
            }

            if (dto.UsuarioMunicipio.HasValue)
            {
                var municipioExists = await _municipioRepository.ExistsAsync(dto.UsuarioMunicipio.Value);
                if (!municipioExists) return BadRequest($"Municipio con id {dto.UsuarioMunicipio.Value} no existe.");
            }

            usuarioExistente.UsuarioNombre = dto.UsuarioNombre;
            usuarioExistente.UsuarioDescripcion = dto.UsuarioDescripcion;
            usuarioExistente.UsuarioLogo = dto.UsuarioLogo;
            usuarioExistente.UsuarioPie = dto.UsuarioPie;
            usuarioExistente.UsuarioEtnia = dto.UsuarioEtnia;
            usuarioExistente.UsuarioDepartamento = dto.UsuarioDepartamento;
            usuarioExistente.UsuarioMunicipio = dto.UsuarioMunicipio;
            usuarioExistente.UsuarioEstado = dto.UsuarioEstado;

            await _usuarioRepository.UpdateAsync(usuarioExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            await _usuarioRepository.DeleteAsync(usuario);
            return NoContent();
        }
    }
}
