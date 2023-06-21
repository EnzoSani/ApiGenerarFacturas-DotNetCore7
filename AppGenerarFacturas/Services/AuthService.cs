using AppGenerarFacturas.DTOS;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppGenerarFacturas.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateToken(UserResponse user)
        {
            //obtenemos la key de el archivo que configuramos en appsettings.Json
            var key = _configuration.GetValue<string>("AppSettings:Key");
            //Transformamos esa key en un array
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Name));
            claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            claims.AddClaim(new Claim(ClaimTypes.Role, "User"));

            //Creamos una credencial para nuestro token
            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            //Creamos el detalle de nuestro token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialesToken
            };

            //Creamos los controladores de Jwt
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            //Obtenemos el Token
            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            //retornamos el Token
            return tokenCreado;



        }


    }
}
