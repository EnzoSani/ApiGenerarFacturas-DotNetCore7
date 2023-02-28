using AppGenerarFacturas.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppGenerarFacturas.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };
            if(userAccounts.UserName == "Admin" ) 
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else if(userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id); 
        }

        public static UserTokens GetTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();

                if(model == null)
                {
                    throw new ArgumentException(nameof(model));
                }

                // Obtein Secret Key 
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                DateTime expiretime = DateTime.UtcNow.AddDays(1);
                // Validity of our token 
                userToken.Validity = expiretime.TimeOfDay;
                // El objeto "JwtSecurityToken" se inicializa con la información de emisor y audiencia proporcionada por el objeto "jwtSettings",
                // las reclamaciones de usuario obtenidas anteriormente, la hora actual y el tiempo de expiración, y las credenciales de firma obtenidas a partir de la clave secreta
                var JwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expiretime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));
                ////Se utiliza un objeto "JwtSecurityTokenHandler" para generar una cadena de caracteres que representa el token JWT y se asigna esta cadena,
                ///junto con otros datos de usuario relevantes, al objeto "UserTokens" que se devuelve al final del método.
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(JwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;

                return userToken;



            }
            catch (Exception ex )
            {

                throw new Exception("Error generatin the JWT",ex);
            }
        }

    }
}
