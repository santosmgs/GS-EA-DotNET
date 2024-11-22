using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyAwareness.Data;
using EnergyAwareness.Models;

namespace EnergyAwareness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EletronicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EletronicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eletronicos = await _context.Eletronicos.ToListAsync();
            return Ok(eletronicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eletronico = await _context.Eletronicos.FindAsync(id);
            if (eletronico == null) return NotFound();
            return Ok(eletronico);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Eletronico eletronico)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Eletronicos.Add(eletronico);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = eletronico.IdEletronico }, eletronico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Eletronico eletronico)
        {
            if (id != eletronico.IdEletronico) return BadRequest();
            _context.Entry(eletronico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eletronico = await _context.Eletronicos.FindAsync(id);
            if (eletronico == null) return NotFound();
            _context.Eletronicos.Remove(eletronico);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
