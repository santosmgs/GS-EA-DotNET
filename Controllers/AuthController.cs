using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnergyAwareness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Endpoint de login para gerar o token JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                // Verifica as credenciais do usuário
                var userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(loginRequest.Email);

                // Cria um token JWT para o usuário
                var customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(userRecord.Uid);

                // Retorna o token JWT
                return Ok(new { token = customToken });
            }
            catch (FirebaseAuthException ex)
            {
                return Unauthorized(new { message = "Erro de autenticação", error = ex.Message });
            }
        }

        // Endpoint protegido, somente acessível com o token JWT
        [Authorize]
        [HttpGet("protected")]
        public IActionResult GetProtectedData()
        {
            return Ok(new
            {
                Message = "Acesso concedido! Este é um endpoint protegido.",
                User = User.Identity?.Name ?? "Usuário desconhecido"
            });
        }
    }

    // Modelo para a requisição de login
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}