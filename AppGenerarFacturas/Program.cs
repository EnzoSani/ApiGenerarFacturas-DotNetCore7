// 1 Using to work with Entity Framwork
using Microsoft.EntityFrameworkCore;
using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas;
using Microsoft.OpenApi.Models;
using AppGenerarFacturas.Services;
using AppGenerarFacturas.Utilities;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AppGenerarFacturas.Services.contracts;

var builder = WebApplication.CreateBuilder(args);

// 2  Connection with Sql server express
const string CONNECTIONNAME = "DefaultConnection";
var conectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3 Add Context to services of builder
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(conectionString));


// 4 Add custom Services ( foolder Services)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInvoiseLineService, InvoiseLineService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

//obtenemos clave secreta
// config Jwt to be able to use it  in all the Proyect.
var key = builder.Configuration.GetValue<string>("AppSettings:Key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

// Add services to the container.

builder.Services.AddControllers();


// 8 Add authorization 

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("UseronlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
//});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9 Config Swager to take care of athorization of Jwt
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(AuthProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NgOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
