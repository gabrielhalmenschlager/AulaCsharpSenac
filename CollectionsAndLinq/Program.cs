using CollectionsAndLinq;

var pessoas = new List<Pessoa>
{
    new Pessoa
    {
        Id = 1,
        Nome = "Gabriel",
        DataDeNascimento = new DateTime(2007, 12, 14).Year
    },
    new Pessoa
    {
        Id = 2,
        Nome = "Pedro",
        DataDeNascimento = new DateTime(2007, 9, 11).Year
    },
    new Pessoa
    {
        Id = 3,
        Nome = "Guilherme",
        DataDeNascimento = new DateTime(1999, 6, 17).Year
    }
};

// Todas pessoas
Console.WriteLine("\n---------- Pessoas ----------");
foreach (var pessoa in pessoas)
{
    Console.WriteLine($"Id: {pessoa.Id}, Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataDeNascimento}");
}

// Pessoas com Id maior que 1
var pessoasFiltrados = pessoas.Where(p => p.Id > 1);

Console.WriteLine("\n---------- Pessoas Filtradas ----------");
foreach (var pessoa in pessoasFiltrados)
{
    Console.WriteLine($"Id: {pessoa.Id}, Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataDeNascimento}");
}

// Pessoas response com mapper
var pessoasResponse = pessoas.Select(p => new PessoaResponse
{
    Id = p.Id,
    Nome = p.Nome,
});

Console.WriteLine("\n---------- Pessoas Response ----------");
foreach (var pessoa in pessoasResponse)
{
    Console.WriteLine($"Id: {pessoa.Id}, Nome: {pessoa.Nome}");
}

// Pessoas ordenadas por nome usando orderBy
var pessoasOrdenadas = pessoas.OrderBy(p => p.Nome);
Console.WriteLine("\n---------- Pessoas Ordenadas ----------");
foreach (var pessoa in pessoasOrdenadas)
{
    Console.WriteLine($"Id: {pessoa.Id}, Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataDeNascimento}");
}

// Buscar uma pessoa com base em uma condição
Console.WriteLine("\n---------- Pessoa Buscada ----------");
Pessoa pessoaBuscada = pessoas.FirstOrDefault(p => p.Nome == "Guilherme");
if (pessoaBuscada == null)
{
    Console.WriteLine("Nenhuma pessoa encontrada.");
    return;
}
else
{
    Console.WriteLine($"Nome: {pessoaBuscada.Nome}");
}