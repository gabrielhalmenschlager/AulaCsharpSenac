using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Calculadora
{
    public double Numero1 { get; set; }

    public double Numero2 { get; set; }

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
        }
        var divisao = Numero1 / Numero2;
        Console.WriteLine($"{Numero1} / {Numero2} = {divisao}");
    }
}