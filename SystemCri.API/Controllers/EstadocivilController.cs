using Microsoft.AspNetCore.Mvc;
using SystemCri.API.DTOs;
using SystemCri.Domain.Entities;
using SystemCri.Domain.Interfaces;

namespace SystemCri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadocivilController : ControllerBase
    {
        private readonly IEstadocivilRepository _repo;

        public EstadocivilController(IEstadocivilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadocivilResponseDto>>> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(i => new EstadocivilResponseDto
            {
                Id = i.EstadocCod,
                EstadocNom = i.EstadocNom,
                EstadocDescrip = i.EstadocDescrip
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadocivilResponseDto>> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(new EstadocivilResponseDto
            {
                Id = item.EstadocCod,
                EstadocNom = item.EstadocNom,
                EstadocDescrip = item.EstadocDescrip
            });
        }

        [HttpPost]
        public async Task<ActionResult<EstadocivilResponseDto>> Post(EstadocivilCreateDto dto)
        {
            var entity = new Estadocivil
            {
                EstadocNom = dto.EstadocNom,
                EstadocDescrip = dto.EstadocDescrip
            };

            await _repo.AddAsync(entity);

            var response = new EstadocivilResponseDto
            {
                Id = entity.EstadocCod,
                EstadocNom = entity.EstadocNom,
                EstadocDescrip = entity.EstadocDescrip
            };

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EstadocivilUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.EstadocNom = dto.EstadocNom;
            existing.EstadocDescrip = dto.EstadocDescrip;

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
