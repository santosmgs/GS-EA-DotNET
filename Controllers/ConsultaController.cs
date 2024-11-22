using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyAwareness.Data;
using EnergyAwareness.Models;

namespace EnergyAwareness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/consulta
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _context.Consultas.ToListAsync();
            return Ok(consultas);
        }

        // GET: api/consulta/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return NotFound();
            return Ok(consulta);
        }

        // POST: api/consulta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Consulta consulta)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = consulta.IdConsultas }, consulta);
        }

        // PUT: api/consulta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.IdConsultas) return BadRequest();
            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/consulta/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return NotFound();
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
