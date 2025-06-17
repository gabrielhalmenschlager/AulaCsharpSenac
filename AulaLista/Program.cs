
using AulaLista;

var pessoas = new List<Pessoa>();

var pessoaUm = new Pessoa();
pessoaUm.Nome = "Gabriel";
pessoaUm.DataDeNascimento = 2007;
pessoas.Add(pessoaUm);

foreach (var pessoa in pessoas)
{
    Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataDeNascimento}");
}



var numeros = new List<int>();

numeros.Add(0);
numeros.Add(1);
numeros.Add(2);
numeros.Add(3);

foreach (var numero in numeros)
{
    Console.WriteLine($"O número é {numero}");
}

var nomes = new List<string>();

string nomeUm = "Gabriel";
string nomeDois = "Pedro";
string nomeTres = "Guilherme";

nomes.Add(nomeUm);
nomes.Add(nomeDois);
nomes.Add(nomeTres);

foreach (var nome in nomes)
{
    Console.WriteLine($"O nome é {nome}");
}

nomes.Remove(nomeUm);

int indicePedro = nomes.IndexOf(nomeDois);
Console.WriteLine($"O indice do Pedro é {indicePedro}");
nomes.RemoveAt(indicePedro);

Console.WriteLine();
Console.WriteLine("Após remover o nome Gabriel:");
foreach (var nome in nomes)
{
    Console.WriteLine($"O nome é {nome}");
}
