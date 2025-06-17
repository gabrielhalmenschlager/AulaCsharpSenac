
// Meu Codigo

/*

namespace CadastroAlunos
{
    public class Program
    {
        static List<Aluno> alunos = new List<Aluno>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("========== Escolha a Opção que deseja executar: =========");
                Console.WriteLine("=========================================================");

                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Remover Aluno");
                Console.WriteLine("3 - Listar Alunos");
                Console.WriteLine("4 - Encerrar");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarAluno();
                        break;

                    case "2":
                        RemoverAluno();
                        break;

                    case "3":
                        ListarAlunos();
                        break;

                    case "4":
                        Console.WriteLine("Programa encerrado.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CadastrarAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                alunos.Add(new Aluno { Nome = nome });
                Console.WriteLine("Aluno cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Nome inválido.");
            }
        }

        static void RemoverAluno()
        {
            Console.Write("Digite o nome do aluno a ser removido: ");
            string nome = Console.ReadLine();

            var aluno = alunos.Find(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine("Aluno removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }

        static void ListarAlunos()
        {
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }

            Console.WriteLine("\nLista de Alunos:");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"- {aluno.Nome}");
            }
        }
    }
 }

*/

// Codigo do Professor

using System.Runtime.CompilerServices;

var alunos = new List<string>();

bool deveContinuar = true;

while (deveContinuar)
{
    Console.WriteLine("Bem vindo ao cadastro de alunos!!!");
    Console.WriteLine("\nEscolha uma opção avaixo:");
    Console.WriteLine("1. Adicionar aluno");
    Console.WriteLine("2. Remover aluno");
    Console.WriteLine("3. Listar aluno");
    Console.WriteLine("0. Sair do programa");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite o nome do aluno");
            string nomeAlunoAdicionar = Console.ReadLine();
            Console.WriteLine($"Aluno {nomeAlunoAdicionar} foi adicionado com sucesso");
            alunos.Add(nomeAlunoAdicionar);

            break;
        case "2":
            Console.WriteLine("Digite o nome do aluno a ser removido");
            string nomeAlunoRemover = Console.ReadLine();

            //bool isAlunoRemovido = alunos.Remove(nomeAlunoRemover);

            string isAlunoRemovido = alunos.Find(a => a.Equals(nomeAlunoRemover, StringComparison.OrdinalIgnoreCase));

            if (isAlunoRemovido != null)
            {
                Console.WriteLine($"Aluno {nomeAlunoRemover} foi removido");
            }
            else
            {
                Console.WriteLine($"Aluno {nomeAlunoRemover} não foi encontrado");
            }

            break;
        case "3":
            Console.WriteLine("\n---------- Lista de alunos ----------");
            foreach (var nomeAluno in alunos)
            {
                Console.WriteLine($"Aluno - {nomeAluno}");
            }
            
            break;
        case "0":
            deveContinuar = false;
            
            break;
        default:
            Console.WriteLine("Opção não é valida!");
            
            break;
    }
}
