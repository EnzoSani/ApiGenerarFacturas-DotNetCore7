// 1 Using to work with Entity Framwork
using Microsoft.EntityFrameworkCore;
using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas;
using Microsoft.OpenApi.Models;
using AppGenerarFacturas.Services;

var builder = WebApplication.CreateBuilder(args);

// 2  Connection with Sql server express
const string CONNECTIONNAME = "DefaultConnection";
var conectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3 Add Context to services of builder
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(conectionString));

// 7 Add Service of JWT Autorization 
builder.Services.AddJwtTokenServices(builder.Configuration);

// 4 Add custom Services ( foolder Services)
builder.Services.AddScoped<IUserService, UserService>();


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
builder.Services.AddSwaggerGen(//options =>
//{
//    // We define the segurity for Authorization
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "jWT Authorization using Bearer Scheme"
//    });

//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                  Reference = new OpenApiReference
//                  {
//                      Type = ReferenceType.SecurityScheme,
//                      Id = "Bearer"
//                  }
//            },
//            new string[] {}
//        }
//    });
//}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
