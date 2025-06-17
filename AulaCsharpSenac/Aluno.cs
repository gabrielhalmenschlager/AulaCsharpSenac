namespace CalcularMedia
{
    public class Aluno : Pessoa
    {
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Media { get; private set; }

        public void CalcularMedia()
        {
            Media = (Nota1 + Nota2) / 2;
        }

        public void MensagemNota()
        {
            Console.WriteLine($"Nota 1: {Nota1}");
            Console.WriteLine($"Nota 2: {Nota2}");
            Console.WriteLine($"Média: {Media}");
        }

        public void Aprovado()
        {
            if (Media > 6)
            {
                Console.WriteLine($"\nVocê está aprovado com a média {Media}");
            }
        }

        public void EmRecuperacao()
        {
            if (Media >= 5 && Media <= 6)
            {
                Console.WriteLine($"\nVocê está de recuperação com a média {Media}");
            }
        }

        public void Reprovado()
        {
            if (Media < 5)
            {
                Console.WriteLine($"\nVocê está reprovado com a média {Media}");
            }
        }
    }
}
