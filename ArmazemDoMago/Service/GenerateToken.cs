using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ArmazemDoMago.Service {
    public class GenerateToken {

        // Método para gerar um token de autenticação JWT
        public static object GetToken() {

            // Chave secreta usada para assinar o token
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            // Configuração do token
            var tokenConfig = new SecurityTokenDescriptor {
                // Define a expiração do token
                Expires = DateTime.UtcNow.AddHours(8),

                // Configura as credenciais de assinatura usando uma chave secreta
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            // Cria um manipulador de token JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            // Cria o token com base na configuração
            var token = tokenHandler.CreateToken(tokenConfig);

            // Converte o token em uma representação de string
            var stringToken = tokenHandler.WriteToken(token);

            return new {
                token = stringToken,
            };
        }
    }
}
