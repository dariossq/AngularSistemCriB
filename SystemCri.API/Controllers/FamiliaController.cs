using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaRepository _repo;

        public FamiliaController(IFamiliaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamiliaResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new FamiliaResponseDto
            {
                Id = i.FamCod,
                FamNombre = i.FamNombre,
                FamDescrip = i.FamDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FamiliaResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new FamiliaResponseDto
            {
                Id = item.FamCod,
                FamNombre = item.FamNombre,
                FamDescrip = item.FamDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<FamiliaResponseDto>> Post(FamiliaCreateDto dto)
        {
            var entity = new Familia
            {
                FamNombre = dto.FamNombre,
                FamDescrip = dto.FamDescrip
            };

            await _repo.AddAsync(entity);

            var response = new FamiliaResponseDto
            {
                Id = entity.FamCod,
                FamNombre = entity.FamNombre,
                FamDescrip = entity.FamDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FamiliaUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.FamNombre = dto.FamNombre;
            existing.FamDescrip = dto.FamDescrip;

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
