
var calculadora = new Calculadora();

Console.WriteLine("=========================================================");
Console.WriteLine("===================== Calculadora! ======================");
Console.WriteLine("=========================================================\n");

calculadora.Numero1 = 10;
calculadora.Numero2 = 5;

Console.WriteLine($"Numero 1: {calculadora.Numero1}");
Console.WriteLine($"Numero 2: {calculadora.Numero2}\n");

calculadora.Soma();
calculadora.Subtracao();
calculadora.Multiplicacao();
calculadora.Divisao();

Console.WriteLine("\n=========================================================");