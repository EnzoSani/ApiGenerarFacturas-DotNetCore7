// 1 Using to work with Entity Framwork
using Microsoft.EntityFrameworkCore;
using AppGenerarFacturas.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 2  Connection with Sql server express
const string CONNECTIONNAME = "DefaultConnection";
var conectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3 Add Context to services of builder
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(conectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
