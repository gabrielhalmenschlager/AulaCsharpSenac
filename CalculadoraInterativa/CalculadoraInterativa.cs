/*

// Meu Codigo

public class CalculadoraInterativa
{
    public double Numero1 { get; set; }
    public double Numero2 { get; set; }

    public void Iniciar()
    {
        Console.WriteLine("=========================================================");
        Console.WriteLine("======== Seja Bem Vindo a Calculadora Interativa ========");
        Console.WriteLine("=========================================================\n");


        string opcao;

        while (true)
        {
            Console.WriteLine("Escolha uma opção:\n");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    SolicitarNumeros();
                    Soma();
                    break;

                case "2":
                    SolicitarNumeros();
                    Subtracao();
                    break;

                case "3":
                    SolicitarNumeros();
                    Multiplicacao();
                    break;

                case "4":
                    SolicitarNumeros();
                    Divisao();
                    break;

                case "5":
                    Console.WriteLine("Programa encerrado.");
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            Console.WriteLine("\n================== Programa encerrado! ==================\n");
        }
    }

    private void SolicitarNumeros()
    {
        Console.Write("\nDigite o primeiro número: ");
        Numero1 = double.Parse(Console.ReadLine());

        Console.Write("Digite o segundo número: ");
        Numero2 = double.Parse(Console.ReadLine());
    }

    public void Soma()
    {
        var soma = Numero1 + Numero2;
        Console.WriteLine($"{Numero1} + {Numero2} = {soma}");
    }

    public void Subtracao()
    {
        var subtracao = Numero1 - Numero2;
        Console.WriteLine($"{Numero1} - {Numero2} = {subtracao}");
    }

    public void Multiplicacao()
    {
        var multiplicacao = Numero1 * Numero2;
        Console.WriteLine($"{Numero1} * {Numero2} = {multiplicacao}");
    }

    public void Divisao()
    {
        if (Numero2 == 0)
        {
            Console.WriteLine("Divisão por zero não é permitida.");
            return;
        }
        var divisao = Numero1 / Numero2;
        Console.WriteLine($"{Numero1} / {Numero2} = {divisao}");
    }
}

*/

// Codigo do Professor

public class CalculadoraInterativa
{
    public decimal NumeroUm { get; set; }
    public decimal NumeroDois { get; set; }

    public decimal Somar()
    {
        return NumeroUm + NumeroDois;
    }

    public decimal Subtrair()
    {
        return NumeroUm - NumeroDois;
    }

    public decimal Multiplicar()
    {
        return NumeroUm * NumeroDois;
    }

    public decimal Dividir()
    {
        return NumeroUm / NumeroDois;
    }
}