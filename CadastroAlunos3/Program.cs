using System;
using System.Collections.Generic;
using System.Linq;
using CadastroAlunos3;

namespace CadastroAlunos
{
    public class Program
    {
        static List<Aluno> alunos = new List<Aluno>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=========================================================");
                Console.WriteLine("========== Escolha a Opção que deseja executar: =========");
                Console.WriteLine("=========================================================");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Remover Aluno");
                Console.WriteLine("3 - Listar Todos os Alunos");
                Console.WriteLine("4 - Listar Alunos por Letra Inicial do Nome");
                Console.WriteLine("5 - Listar Alunos Ordenados (Nome ou Idade)");
                Console.WriteLine("6 - Buscar Aluno por CPF");
                Console.WriteLine("0 - Encerrar");
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
                        ListarPorLetraInicial();
                        break;
                    case "5":
                        ListarOrdenado();
                        break;
                    case "6":
                        ListarPorCpf();
                        break;
                    case "0":
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
            Console.Write("Digite o CPF do aluno: ");
            string cpf = Console.ReadLine();

            bool cpfExiste = alunos.Any(a => a.Cpf == cpf);
            if (cpfExiste)
            {
                Console.WriteLine("CPF já cadastrado. Cadastro não realizado.");
                return;
            }
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("Dados inválidos. Cadastro não realizado.");
                return;
            }

            Console.Write("Digite a idade do aluno: ");
            string idadeInput = Console.ReadLine();

            if (!int.TryParse(idadeInput, out int idade))
            {
                Console.WriteLine("Idade inválida.");
                return;
            }

            var aluno = new Aluno
            {
                Nome = nome,
                Idade = idade,
                Cpf = cpf,
                Matricula = Guid.NewGuid()
            };

            alunos.Add(aluno);
            Console.WriteLine($"Aluno cadastrado com sucesso! Matrícula: {aluno.Matricula}");
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
            Console.WriteLine("\nLista de Alunos:");

            var alunosDetalhadoResponse = alunos.Select(a => new AlunoDetalhadoResponse
            {
                Nome = a.Nome,
                Idade = a.Idade,
                Cpf = a.Cpf,
                Matricula = a.Matricula
            });

            foreach (var aluno in alunosDetalhadoResponse)
            {
                Console.WriteLine($"- Nome: {aluno.Nome}, Idade: {aluno.Idade}, CPF: {aluno.Cpf}, Matrícula: {aluno.Matricula}");
            }
        }

        static void ListarPorLetraInicial()
        {
            Console.Write("Digite a letra inicial do nome: ");
            string letra = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(letra) || letra.Length != 1)
            {
                Console.WriteLine("Entrada inválida. Digite apenas uma letra.");
                return;
            }

            var filtrados = alunos.Where(a => a.Nome.StartsWith(letra, StringComparison.OrdinalIgnoreCase)).OrderBy(a => a.Nome).ToList();

            if (!filtrados.Any())
            {
                Console.WriteLine("Nenhum aluno encontrado com essa letra.");
                return;
            }

            Console.WriteLine($"\nAlunos com a letra {letra}':");

            var alunosResponse = filtrados.Select(a => new AlunoResponse
            {
                Nome = a.Nome,
                Idade = a.Idade,
            });

            foreach (var aluno in alunosResponse)
            {
                Console.WriteLine($"- Nome: {aluno.Nome}, Idade: {aluno.Idade}");
            }
        }


        static void ListarOrdenado()
        {
            Console.WriteLine("Ordenar por:\n1 - Nome\n2 - Idade");
            string escolha = Console.ReadLine();

            List<Aluno> ordenados;
            if (escolha == "1")
            {
                ordenados = alunos.OrderBy(a => a.Nome).ToList();
            }
            else if (escolha == "2")
            {
                ordenados = alunos.OrderBy(a => a.Idade).ToList();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Console.WriteLine("\nAlunos ordenados:");

            var alunosResponse = ordenados.Select(a => new AlunoResponse
            {
                Nome = a.Nome,
                Idade = a.Idade,
            });

            foreach (var aluno in alunosResponse)
            {
                Console.WriteLine($"- Nome: {aluno.Nome}, Idade: {aluno.Idade}");
            }
        }

        static void ListarPorCpf()
        {
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            var alunoDetalhadoResponse = new AlunoDetalhadoResponse
            {
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                Cpf = aluno.Cpf,
                Matricula = aluno.Matricula
            };

            Console.WriteLine($"- Nome: {alunoDetalhadoResponse.Nome}, Idade: {alunoDetalhadoResponse.Idade}, CPF: {alunoDetalhadoResponse.Cpf}, Matrícula: {alunoDetalhadoResponse.Matricula}");
        }
    }
}
