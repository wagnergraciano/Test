using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<VotingService>();  // Register the voting service
builder.Services.AddControllers();            // Add controllers to the service container

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();
app.MapControllers();  // Map the controllers to the routing system

app.Run();