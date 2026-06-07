using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemCri.API.Controllers
{
    // Cambiado la ruta para que sea consistente con el nombre del controlador
    [Route("api/[controller]")]
    [ApiController]
    public class DeptosController : ControllerBase
    {
        private readonly IDeptoRepository _repository;

        public DeptosController(IDeptoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptoResponseDto>>> GetDeptos()
        {
            var deptos = await _repository.GetAllAsync();
            var result = deptos.Select(d => new DeptoResponseDto
            {
                Id = d.DeptoCod,
                DeptoNom = d.DeptoNom,
                DeptoDescrip = d.DeptoDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeptoResponseDto>> GetDepto(int id)
        {
            var depto = await _repository.GetByIdAsync(id);
            if (depto == null) return NotFound();

            var response = new DeptoResponseDto
            {
                Id = depto.DeptoCod,
                DeptoNom = depto.DeptoNom,
                DeptoDescrip = depto.DeptoDescrip
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DeptoResponseDto>> PostDepto(DeptoCreateDto dto)
        {
            var nuevoDepto = new Depto
            {
                DeptoNom = dto.DeptoNom,
                DeptoDescrip = dto.DeptoDescrip
            };

            await _repository.AddAsync(nuevoDepto);

            var response = new DeptoResponseDto
            {
                Id = nuevoDepto.DeptoCod,
                DeptoNom = nuevoDepto.DeptoNom,
                DeptoDescrip = nuevoDepto.DeptoDescrip
            };

            return CreatedAtAction(nameof(GetDepto), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepto(int id, DeptoCreateDto dto)
        {
            var deptoExistente = await _repository.GetByIdAsync(id);
            if (deptoExistente == null) return NotFound();

            deptoExistente.DeptoNom = dto.DeptoNom;
            deptoExistente.DeptoDescrip = dto.DeptoDescrip;

            await _repository.UpdateAsync(deptoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepto(int id)
        {
            var depto = await _repository.GetByIdAsync(id);
            if (depto == null) return NotFound();

            await _repository.DeleteAsync(depto);
            return NoContent();
        }
    }
}
