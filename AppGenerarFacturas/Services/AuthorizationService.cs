using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.Services.contracts;

namespace AppGenerarFacturas.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public AuthorizationService(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerateToken(string idUsuario)
        {
            // tomamos la key de appSettings
            var key = _configuration.GetValue<string>("AppSettings:Key");

            // convertimos la key en una secuencia de bytes
            var keyBytes = Encoding.ASCII.GetBytes(key);

            // pasamos info del usuario al token
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            //credenciales para el token
            var tokenCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature);

            // detalle del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = tokenCredentials
            };

            //controladores del JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            // obtenemos token
            var CreatedToken = tokenHandler.WriteToken(tokenConfig);

            return CreatedToken;

        }
        public async Task<AuthorizationResponse> ReturnToken(AuthorizationRequest authorization)
        {
            var usuario_encontrado = _context.Users.FirstOrDefault(x =>
            x.Name == authorization.UserName &&
            x.Password == authorization.Password);

            if(usuario_encontrado == null)
            {
                return await Task.FromResult<AuthorizationResponse>(null);

            }

            string tokenCreado = GenerateToken(usuario_encontrado.Id.ToString());

            return new AuthorizationResponse { Token = tokenCreado, Result = true, Msg = "Ok" };
        }

        public Task<AuthorizationService> ReturnToken(AuthorizationService response)
        {
            throw new NotImplementedException();
        }
    }
}
