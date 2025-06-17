namespace CalcularMedia;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public void MensagemPessoa()
    {
        Console.WriteLine($"Olá, {Nome}! você tem {Idade} anos");
    }

    public void MenorIdade()
    {
        if (Idade < 18)
        {
            Console.WriteLine($"Você é menor de idade porque tem {Idade} anos\n");
        }   
    }

    public void MaiorIdade()
    {
        if (Idade > 18)
        {
            Console.WriteLine($"Você é maior de idade com {Idade} anos\n");
        }
    }
}