using Fase5_CalculadoraDeDescontoComLogin.Interfaces;
using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class MainService
    {
        private static IRegisterService _registerService;
        public static List<Client> clientsRegistered = new List<Client>();
        public static Client clientLogged;

        public MainService(IRegisterService registerService) {
            _registerService = registerService;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(" [1] Registrar              ");
            Console.WriteLine(" [2] Login                  ");
            Console.WriteLine(" [3] Logout                 ");
            Console.WriteLine(" [4] Incluir Produto        ");
            Console.WriteLine(" [5] Excluir Produtos       ");
            Console.WriteLine(" [6] Calcular Desconto      ");
            Console.WriteLine(" [7] Relatório de Produtos  ");
            Console.WriteLine("----------------------------");
        }

        public void Register()
        {
            //TODO: Preciso corrigir os nulos depois.
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");
            string phoneNumber = Console.ReadLine();

            var registerResult = _registerService.Register(login, password, phoneNumber, clientsRegistered);


            if (!registerResult.Success)
            {
                Console.WriteLine("Erro no registro: ");

                foreach (var error in registerResult.Errors) {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                    Thread.Sleep(2000);
                    return;
                }
            }
            clientsRegistered.Add(registerResult.Data);
            Console.Clear();
            Console.WriteLine($"Usuário {registerResult.Data.Login} registrado com sucesso!");
            Thread.Sleep(3000);
        }
    }
}
