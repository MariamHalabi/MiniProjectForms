using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiniProjectForms.Data;
using MiniProjectForms.Services;
using System.Net;
using Xamarin.Forms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddDbContext<MiniProjectFormsContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=MiniProjectForms;Trusted_Connection=True;TrustServerCertificate=true", b => b.MigrationsAssembly("MiniProjectForms.API"));
});


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
