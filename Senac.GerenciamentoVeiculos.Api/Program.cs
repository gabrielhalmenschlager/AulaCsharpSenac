using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;
using Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(
        "Server=localhost,1433;Database=gerenciamento_veiculo;User Id=sa;Password=Admin123!;TrustServerCertificate=True;")
    );

builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

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
