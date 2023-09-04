using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ArmazemDoMago.Service {
    public class GenerateToken {

        public static object GetToken() {

            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor {

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var stringToken = tokenHandler.WriteToken(token);

            return new {
                token = stringToken,
            };
        }

    }
}
