
/*

// Meu Codigo

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

            Console.Write("Digite a idade do aluno: ");
            string idadeInput = Console.ReadLine();

            if (!int.TryParse(idadeInput, out int idade))
            {
                Console.WriteLine("Idade inválida.");
                return;
            }

            Console.Write("Digite o CPF do aluno: ");
            string cpf = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("Dados inválidos. Cadastro não realizado.");
                return;
            }

            bool cpfExiste = alunos.Any(a => a.Cpf == cpf);

            if (cpfExiste)
            {
                Console.WriteLine("CPF já cadastrado. Cadastro não realizado.");
                return;
            }

            alunos.Add(new Aluno { Nome = nome, Idade = idade, Cpf = cpf });
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }


        static void RemoverAluno()
        {
            Console.Write("Digite o CPF do aluno a ser removido: ");
            string cpf = Console.ReadLine();

            var cpfAluno = alunos.Find(a => a.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (cpfAluno != null)
            {
                alunos.Remove(cpfAluno);
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
                Console.WriteLine($"- Nome: {aluno.Nome}, Idade: {aluno.Idade}, CPF: {aluno.Cpf}");
            }
        }
    }
}

*/

// Codigo do Professor

var alunos = new List<Aluno>();

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

            Console.WriteLine("Digite o CPF do aluno (somente números)");
            string cpfAlunoAdicionar = Console.ReadLine();

            bool cpfJaExiste = alunos.Any(a => a.Cpf == cpfAlunoAdicionar);
            
            if (cpfJaExiste)
            {
                Console.WriteLine($"O CPF {cpfAlunoAdicionar} ja existe na base");
                break;
            }

            Console.WriteLine("Digite o nome do aluno");
            string nomeAlunoAdicionar = Console.ReadLine();

            Console.WriteLine("Digite a idade do aluno");
            string idadeAlunoAdicionar = Console.ReadLine();
            int idadeInt = int.Parse(idadeAlunoAdicionar);

            var alunoAdicionar = new Aluno
            {
                Nome = nomeAlunoAdicionar,
                Cpf = cpfAlunoAdicionar,
                Idade = idadeInt
            };
            
            alunos.Add(alunoAdicionar);

            Console.WriteLine($"Aluno {nomeAlunoAdicionar} foi adicionado com sucesso");

            break;
        case "2":
            Console.WriteLine("Digite o nome do aluno a ser removido");
            string cpfAlunoRemover = Console.ReadLine();

            var alunoRemover = alunos.Find(a => a.Cpf.Equals(cpfAlunoRemover, StringComparison.OrdinalIgnoreCase));

            if (alunoRemover != null)
            {
                alunos.Remove(alunoRemover);
                Console.WriteLine($"Aluno {alunoRemover} foi removido");
            }
            else
            {
                Console.WriteLine($"Aluno {alunoRemover} não foi encontrado");
            }

            break;
        case "3":
            Console.WriteLine("\n---------- Lista de alunos ----------");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Aluno: {aluno.Nome} - Idade: {aluno.Nome} - Cpf: {aluno.Cpf}");
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





