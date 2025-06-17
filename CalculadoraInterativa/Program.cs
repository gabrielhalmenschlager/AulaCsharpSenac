/*

// Meu Codigo

CalculadoraInterativa calculadoraInterativa = new CalculadoraInterativa();
calculadoraInterativa.Iniciar();

*/

// Codigo do Professor

while (true)
{
    var calculadoraInterativa = new CalculadoraInterativa();
    Console.WriteLine("Bem vindo a calculadora interativa. Para continuar, digite qualquer tecla. Para sair digite 0");

    string inputInicial = Console.ReadLine();

    if (inputInicial == Constantes.SAIR)
    {
        break;
    }

    decimal valorUm = 0;
    decimal valorDois = 0;
    bool valoresValidos = false;

    try
    {
        Console.WriteLine("Digite o valor 1");
        string valorUmInput = Console.ReadLine();
        valorUm = decimal.Parse(valorUmInput);
        calculadoraInterativa.NumeroUm = valorUm;

        Console.WriteLine("Digite o valor 2");
        string valorDoisInput = Console.ReadLine();
        valorDois = decimal.Parse(valorDoisInput);
        calculadoraInterativa.NumeroUm = valorDois;

        valoresValidos = true;
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Valor inválido. Por valor digite um valor numérico");
    }

    if (valoresValidos)
    {
        Console.WriteLine("Digite as operação desejada: 1 - soma; 2 - subtração; 3, multiplicação, 4 - divisão");
        string operacao = Console.ReadLine();

        decimal resultado = 0;

        if (operacao == Constantes.SOMAR)
        {
            resultado = calculadoraInterativa.Somar();
            ExibirResultado(resultado, nameof(CalculadoraInterativa.Somar));
        }
        else if (operacao == Constantes.SUBTRAIR)
        {
            resultado = calculadoraInterativa.Subtrair();
            ExibirResultado(resultado, nameof(CalculadoraInterativa.Subtrair));
        }
        else if (operacao == Constantes.MULTIPLICAR)
        {
            resultado = calculadoraInterativa.Multiplicar();
            ExibirResultado(resultado, nameof(CalculadoraInterativa.Multiplicar));
        }
        else if (operacao == Constantes.DIVIDIR)
        {
            resultado = calculadoraInterativa.Dividir();
            ExibirResultado(resultado, nameof(CalculadoraInterativa.Dividir));
        }
        else
        {
            Console.WriteLine("Operação inválida!");
        }
    }
}

static void ExibirResultado(decimal resultado, string operacao)
{
    Console.WriteLine($"O resultado operação {operacao} é {resultado}");
}