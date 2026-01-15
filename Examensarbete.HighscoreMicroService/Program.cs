using Microsoft.AspNetCore.Builder;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Examensarbete.HighscoreMicroService.Core.Services;
using Examensarbete.HighscoreMicroService.Data.Interfaces;
using Examensarbete.HighscoreMicroService.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHighScoresService, HighScoresService>();
builder.Services.AddScoped<IHighScoresRepository, HighScoresRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
