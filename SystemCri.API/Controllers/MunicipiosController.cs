using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IDeptoRepository _deptoRepository;

        public MunicipiosController(IMunicipioRepository municipioRepository, IDeptoRepository deptoRepository)
        {
            _municipioRepository = municipioRepository;
            _deptoRepository = deptoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunicipioResponseDto>>> GetMunicipios()
        {
            var municipios = await _municipioRepository.GetAllAsync();
            var result = municipios.Select(m => new MunicipioResponseDto
            {
                Id = m.MunicipioCod,
                MunicipioNom = m.MunicipioNom,
                DeptoCod = m.DeptoCod
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MunicipioResponseDto>> GetMunicipio(int id)
        {
            var municipio = await _municipioRepository.GetByIdAsync(id);
            if (municipio == null) return NotFound();

            var response = new MunicipioResponseDto
            {
                Id = municipio.MunicipioCod,
                MunicipioNom = municipio.MunicipioNom,
                DeptoCod = municipio.DeptoCod
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<MunicipioResponseDto>> PostMunicipio(MunicipioCreateDto dto)
        {
            // Si se proporciona DeptoCod, verificar que existe
            if (dto.DeptoCod.HasValue)
            {
                var deptoExists = await _deptoRepository.ExistsAsync(dto.DeptoCod.Value);
                if (!deptoExists) return BadRequest($"Depto con id {dto.DeptoCod.Value} no existe.");
            }

            var nuevo = new Municipio
            {
                MunicipioNom = dto.MunicipioNom,
                DeptoCod = dto.DeptoCod
            };

            await _municipioRepository.AddAsync(nuevo);

            var response = new MunicipioResponseDto
            {
                Id = nuevo.MunicipioCod,
                MunicipioNom = nuevo.MunicipioNom,
                DeptoCod = nuevo.DeptoCod
            };

            return CreatedAtAction(nameof(GetMunicipio), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipio(int id, MunicipioCreateDto dto)
        {
            var existente = await _municipioRepository.GetByIdAsync(id);
            if (existente == null) return NotFound();

            if (dto.DeptoCod.HasValue)
            {
                var deptoExists = await _deptoRepository.ExistsAsync(dto.DeptoCod.Value);
                if (!deptoExists) return BadRequest($"Depto con id {dto.DeptoCod.Value} no existe.");
            }

            existente.MunicipioNom = dto.MunicipioNom;
            existente.DeptoCod = dto.DeptoCod;

            await _municipioRepository.UpdateAsync(existente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipio(int id)
        {
            var municipio = await _municipioRepository.GetByIdAsync(id);
            if (municipio == null) return NotFound();

            await _municipioRepository.DeleteAsync(municipio);
            return NoContent();
        }
    }
}
