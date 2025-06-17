using System.Reflection;
using GerenciamentoTurmasApi.Aplicacao.Alunos.Interface;
using GerenciamentoTurmasApi.Aplicacao.Alunos.Servico;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Interface;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Servico;
using GerenciamentoTurmasApi.Aplicacao.Turmas.Interface;
using GerenciamentoTurmasApi.Aplicacao.Turmas.Servico;
using GerenciamentoTurmasApi.Dominio.Alunos.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Alunos.Servico;
using GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Exercicios.Servico;
using GerenciamentoTurmasApi.Dominio.Turmas.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Turmas.Servico;

var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Injeção de dependências
builder.Services.AddSingleton<IAlunosAppServico, AlunosAppServico>();
builder.Services.AddSingleton<IExerciciosAppServico, ExerciciosAppServico>();
builder.Services.AddSingleton<ITurmasAppServico, TurmasAppServico>();
builder.Services.AddSingleton<IAlunosServico, AlunosServico>();
builder.Services.AddSingleton<IExerciciosServico, ExerciciosServico>();
builder.Services.AddSingleton<ITurmasServico, TurmasServico>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
