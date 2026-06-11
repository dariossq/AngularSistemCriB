using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _repo;

        public GeneroController(IGeneroRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new GeneroResponseDto
            {
                Id = i.GeneroCod,
                GeneroNom = i.GeneroNom,
                GeneroSigla = i.GeneroSigla
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new GeneroResponseDto
            {
                Id = item.GeneroCod,
                GeneroNom = item.GeneroNom,
                GeneroSigla = item.GeneroSigla
            });
        }

        [HttpPost]
        public async Task<ActionResult<GeneroResponseDto>> Post(GeneroCreateDto dto)
        {
            var entity = new Genero
            {
                GeneroNom = dto.GeneroNom,
                GeneroSigla = dto.GeneroSigla
            };

            await _repo.AddAsync(entity);

            var response = new GeneroResponseDto
            {
                Id = entity.GeneroCod,
                GeneroNom = entity.GeneroNom,
                GeneroSigla = entity.GeneroSigla
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GeneroUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.GeneroNom = dto.GeneroNom;
            existing.GeneroSigla = dto.GeneroSigla;

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
