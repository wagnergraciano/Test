using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<VotingService>();  // Register the voting service
builder.Services.AddControllers();            // Add controllers to the service container

// Adicionando a configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Permitir requisições do frontend Angular
              .AllowAnyHeader()                      // Permitir qualquer cabeçalho
              .AllowAnyMethod();                     // Permitir qualquer método HTTP (GET, POST, PUT, DELETE)
    });
});

var app = builder.Build();

// Aplicar o middleware CORS
app.UseCors("AllowLocalhost");  // Usar a política de CORS "AllowLocalhost"

// Configure the HTTP request pipeline
app.UseRouting();
app.MapControllers();  // Map the controllers to the routing system

app.Run();