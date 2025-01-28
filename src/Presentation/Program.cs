using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IMousePositionService, MousePositionService>();
builder.Services.AddScoped<IMousePositionRepository, MousePositionRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(); // Включение статических файлов (wwwroot)
app.UseRouting();

app.MapControllers();

// Для обслуживания index.html из wwwroot
app.MapFallbackToFile("index.html");

app.Run();
