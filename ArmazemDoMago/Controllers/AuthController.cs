using ArmazemDoMago.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArmazemDoMago.Controllers {
        [ApiController]
    public class AuthController : Controller {

        [Route("api/[controller]")]

        [HttpPost]

        public IActionResult Auth(string name, string password) {
            
            if (name == "henrique" && password == "123456") {
                var token = GenerateToken.GetToken();
                return Ok(token);
            }

            return BadRequest("username or password incorrect");
        
        }
    }
}
