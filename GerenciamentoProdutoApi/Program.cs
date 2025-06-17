using System.Reflection;
using GerenciamentoProdutoApi.Aplicacao.Produto.Interface;
using GerenciamentoProdutoApi.Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conectionString = "Server=(localdb)\\MSSQLLocalDB; Database=GerenciamentoProduto; Trusted-Connection=True;";

builder.Services.AddDbContext<AppDbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(conectionString)));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMvc();
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
