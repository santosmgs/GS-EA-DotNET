using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyAwareness.Data;
using EnergyAwareness.Models;

namespace EnergyAwareness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ValorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/valor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var valores = await _context.Valores.ToListAsync();
            return Ok(valores);
        }

        // GET: api/valor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var valor = await _context.Valores.FindAsync(id);
            if (valor == null) return NotFound();
            return Ok(valor);
        }

        // POST: api/valor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Valor valor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Valores.Add(valor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = valor.NrPotencia }, valor);
        }

        // PUT: api/valor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Valor valor)
        {
            if (id != valor.NrPotencia) return BadRequest();
            _context.Entry(valor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/valor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var valor = await _context.Valores.FindAsync(id);
            if (valor == null) return NotFound();
            _context.Valores.Remove(valor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
