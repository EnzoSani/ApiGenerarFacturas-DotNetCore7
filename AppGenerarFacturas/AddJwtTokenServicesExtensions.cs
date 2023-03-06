using AppGenerarFacturas.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AppGenerarFacturas
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add jwt Settings
            var bindJwtSettings = new JwtSettings();
            configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
            // Add Singletton of jwt Settings
            services.AddSingleton(bindJwtSettings);
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                        ValidateIssuer = bindJwtSettings.ValidateIssuer,
                        ValidAudience = bindJwtSettings.ValidAudience,
                        ValidateAudience = bindJwtSettings.ValidateAudience,
                        RequireExpirationTime = bindJwtSettings.RequiredExpirationTime,
                        ValidateLifetime = bindJwtSettings.ValidLifetime,
                        ClockSkew = TimeSpan.FromDays(1)

                    };
                });
        }
    }
}
