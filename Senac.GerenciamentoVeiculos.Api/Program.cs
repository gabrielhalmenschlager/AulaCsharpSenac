using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Domain.Services.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Services.Carro;
using Senac.GerenciamentoVeiculos.Domain.Services.Moto;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;
using Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(
        "Server=(localdb)\\MSSQLLocalDB; Database=gerenciamento_veiculo; Trusted_Connection=True;")
    );

builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<ICaminhaoService, CaminhaoService>();
builder.Services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();

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
