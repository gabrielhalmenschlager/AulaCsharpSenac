
namespace ProjetoBanco
{
    public class Gerenciamento
    {
        private Conta conta;

        public void Iniciar()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("==================== Seja Bem Vindo! ====================");
            Console.WriteLine("=========================================================");
            Console.WriteLine("========== Escolha a Opção que deseja executar: ==========");
            Console.WriteLine("=========================================================");

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("========== Escolha a Opção que deseja executar: ==========");
                Console.WriteLine("=========================================================");

                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1 - Cadastrar Conta");
                Console.WriteLine("2 - Ver Saldo");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Encerrar");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarConta();
                        break;

                    case "2":
                        VerSaldo();
                        break;

                    case "3":
                        Depositar();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Console.WriteLine("Programa encerrado.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void CadastrarConta()
        {
            Console.Write("Digite o nome do titular: ");
            string nome = Console.ReadLine();

            Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
            string data = Console.ReadLine();
            if (!DateTime.TryParse(data, out DateTime dataDeNascimento))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            string numero = Console.ReadLine();

            conta = new Conta(numero, nome, dataDeNascimento);
            Console.WriteLine("Conta cadastrada com sucesso.");
            Console.WriteLine($"Titular: {conta.Nome}, Número: {conta.NumeroDaConta}, Nascimento: {conta.DataDeNascimento.ToShortDateString()}");
        }

        private void VerSaldo()
        {
            if (conta != null)
            {
                Console.WriteLine($"Saldo atual: R$ {conta.SaldoAtual()}");
            }
            else
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
        }

        private void Depositar()
        {
            if (conta != null)
            {
                Console.Write("Digite o valor para depositar: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                {
                    conta.Depositar(valorDeposito);
                }
                else
                {
                    Console.WriteLine("Valor inválido.");
                }
            }
            else
            {
                Console.WriteLine("Cadastre uma conta primeiro.");
            }
        }

        private void Sacar()
        {
            if (conta != null)
            {
                Console.Write("Digite o valor para sacar: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                {
                    conta.Sacar(valorSaque);
                }
                else
                {
                    Console.WriteLine("Valor inválido.");
                }
            }
            else
            {
                Console.WriteLine("Cadastre uma conta primeiro.");
            }
        }
    }
}

