using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Domain.Services;
using Senac.LocaGames.Dominio.Models;
using Senac.LocaGames.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(
        "Server=(localdb)\\MSSQLLocalDB; Database=loca_games; Trusted_Connection=True;")
    );

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
