using CalcularImc;

var pessoa = new Imc();

Console.Write("Digite seu nome: ");
pessoa.Nome = Console.ReadLine();

Console.Write("Digite sua idade: ");
pessoa.Idade = int.Parse(Console.ReadLine());

Console.Write("Digite sua altura: ");
pessoa.Altura = double.Parse(Console.ReadLine());

Console.Write("Digite seu peso: ");
pessoa.Peso = double.Parse(Console.ReadLine());

double imc = pessoa.Calcular();
string classificacao = pessoa.Classificar();

Console.WriteLine();
Console.WriteLine($"Nome: {pessoa.Nome}");
Console.WriteLine($"Idade: {pessoa.Idade}");
Console.WriteLine($"Altura: {pessoa.Altura}");
Console.WriteLine($"Peso: {pessoa.Peso}");
Console.WriteLine($"IMC: {imc:F2}");
Console.WriteLine($"Classificação: {classificacao}");
