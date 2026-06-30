using ApiHandler.DataAccess;
using ApiHandler.Interface;
using ApiHandler.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("Server=ROSHAN\\SQLEXPRESS;Database=APIHANDLER;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddOpenApi();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
