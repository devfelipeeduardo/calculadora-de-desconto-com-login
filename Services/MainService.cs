using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Threading;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class MainService
    {
        private static IRegisterService _registerService;
        private static ILoginService _loginService;
        private static ILogoutService _logoutService;
        public static List<Client> clientsRegistered;
        public static Client clientLogged;

        public MainService(IRegisterService registerService, ILoginService loginService, ILogoutService logoutService) {
            _registerService = registerService;
            _loginService = loginService;
            _logoutService = logoutService;
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

        public void RegisterClient()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");
            string phoneNumber = Console.ReadLine();

            var registerResult = _registerService.RegisterClient(login, password, phoneNumber, clientsRegistered);

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

            if (clientsRegistered == null )
            {
                clientsRegistered = new List<Client> { };
            }

            clientsRegistered.Add(registerResult.Data);
            Console.Clear();
            Console.WriteLine($"Usuário {registerResult.Data.Login} registrado com sucesso!");
            Thread.Sleep(3000);
        }

        public void LoginClient()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");

            var loginResult = _loginService.LoginClient(login, password, clientLogged, clientsRegistered);

            if (!loginResult.Success)
            {
                Console.WriteLine("Erro no registro: ");

                foreach (var error in loginResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                    Thread.Sleep(2000);
                    return;
                }
            }

            clientLogged = loginResult.Data;

            Console.Clear();
            Console.WriteLine($"Usuário {loginResult.Data.Login} logado com sucesso!");
            Thread.Sleep(3000);
        }

        public void LogoutClient()
        {
            if (clientLogged == null)
            {
                Console.WriteLine("Não existe nenhum cliente logado.");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine($"O cliente {clientLogged.Login} foi deslogado!");
            Thread.Sleep(3000);

            clientLogged = null;
        }
    }
}
