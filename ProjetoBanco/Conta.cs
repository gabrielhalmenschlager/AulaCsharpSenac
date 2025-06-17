namespace ProjetoBanco;

public class Conta
{
    public string NumeroDaConta { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string Nome { get; set; }
    public decimal Saldo { get; private set; }

    public Conta(string numeroDaConta, string nome, DateTime dataDeNascimento)
    {
        NumeroDaConta = numeroDaConta;
        DataDeNascimento = dataDeNascimento;
        Nome = nome;
        Saldo = 0;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor} realizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Valor inválido para depósito.");
        }
    }

    public bool Sacar(decimal valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor} realizado com sucesso.");
            return true;
        }
        else
        {
            Console.WriteLine("Saldo insuficiente ou valor inválido.");
            return false;
        }
    }

    public decimal SaldoAtual()
    {
        return Saldo;
    }
}
