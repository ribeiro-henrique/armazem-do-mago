using ArmazemDoMago.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArmazemDoMago.Controllers {
    [ApiController]
    public class AuthController : Controller {
        // Rota da API para autenticação
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Auth(string name, string password) {
            // Verifica se as credenciais fornecidas são válidas
            if (name == "developer" && password == "backend") {
                // Gera um token de autenticação válido
                var token = GenerateToken.GetToken();

                // Retorna um código de status OK (200) com o token
                return Ok(token);
            }

            // Retorna um código de status BadRequest (400) com mensagem de erro
            return BadRequest("username or password incorrect");
        }
    }
}
