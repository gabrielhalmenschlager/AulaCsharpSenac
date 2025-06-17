using System;
using System.Collections.Generic;

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
