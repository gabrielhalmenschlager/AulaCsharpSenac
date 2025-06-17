
/* Meu codigo

Console.WriteLine("=========================================================");
Console.WriteLine("====== Digite um numero e verifique se impar ou par =====");
Console.WriteLine("============== ! Apenas numeros inteiros ! ==============");
Console.WriteLine("=========================================================\n");

Console.Write("Digite um número: ");

try
{
    int numero = int.Parse(Console.ReadLine());

    if (numero % 2 == 0)
    {
        Console.WriteLine("O número é par.");
    }
    else
    {
        Console.WriteLine("O número é ímpar.");
    }
}
catch (FormatException)
{
    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
}
catch (OverflowException)
{
    Console.WriteLine("Número muito grande ou muito pequeno para ser um inteiro.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex}");
}

Console.WriteLine("\n=========================================================");

*/



// Codigo do professor

Console.WriteLine("Digite um valor para verificar se é impar ou par: ");
string inputUsuario = Console.ReadLine();

int numero = int.Parse(inputUsuario);

try
{
    if (numero % 2 == 0)
    {
        Console.WriteLine($"O número {numero} é par.");
    }
    else
    {
        Console.WriteLine($"O número {numero} é ímpar.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro ao verificar o valor {inputUsuario}");
}
