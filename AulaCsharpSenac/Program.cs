
using CalcularMedia;

var aluno = new Aluno();

aluno.Nome = "Gabriel";
aluno.Idade = 17;
aluno.Nota1 = 9;
aluno.Nota2 = 7;

aluno.MensagemPessoa();
aluno.MenorIdade();
aluno.MaiorIdade();

Console.WriteLine("Suas notas são:");

aluno.CalcularMedia();
aluno.MensagemNota();
aluno.Aprovado();
aluno.EmRecuperacao();
aluno.Reprovado();

