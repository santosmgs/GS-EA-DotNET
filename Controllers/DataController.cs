using EnergyAwareness.Data;
using EnergyAwareness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnergyAwareness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint para adicionar um usuário
        [HttpPost("usuario")]
        public async Task<IActionResult> AddUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Dados inválidos.");
            }

            // Adiciona o usuário na tabela
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário criado com sucesso.", usuario });
        }

        // Endpoint para adicionar um eletrônico
        [HttpPost("eletronico")]
        public async Task<IActionResult> AddEletronico([FromBody] Eletronico eletronico)
        {
            if (eletronico == null)
            {
                return BadRequest("Dados inválidos.");
            }

            // Adiciona o eletrônico na tabela
            _context.Eletronicos.Add(eletronico);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Eletrônico criado com sucesso.", eletronico });
        }

        // Endpoint para adicionar consulta
        [HttpPost("consulta")]
        public async Task<IActionResult> AddConsulta([FromBody] Consulta consulta)
        {
            if (consulta == null)
            {
                return BadRequest("Dados inválidos.");
            }

            // Adiciona a consulta na tabela
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Consulta criada com sucesso.", consulta });
        }
    }
}
