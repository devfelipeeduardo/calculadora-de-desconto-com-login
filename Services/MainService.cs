using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Threading;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class MainService
    {
        private static IRegisterService _registerService;
        private static ILoginService _loginService;
        public static List<User> usersRegistered;
        public static User userLogged;

        public MainService(IRegisterService registerService, ILoginService loginService) {
            _registerService = registerService;
            _loginService = loginService;
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

        public void RegisterUser()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");
            string phoneNumber = Console.ReadLine();

            var registerResult = _registerService.RegisterUser(login, password, phoneNumber, usersRegistered);

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

            if (usersRegistered == null )
            {
                usersRegistered = new List<User> { };
            }

            usersRegistered.Add(registerResult.Data);
            Console.Clear();
            Console.WriteLine($"Usuário {registerResult.Data.Login} registrado com sucesso!");
            Thread.Sleep(3000);
        }

        public void LoginUser()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");

            var loginResult = _loginService.LoginUser(login, password, userLogged, usersRegistered);

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

            userLogged = loginResult.Data;

            Console.Clear();
            Console.WriteLine($"Usuário {loginResult.Data.Login} logado com sucesso!");
            Thread.Sleep(3000);
        }

        public void LogoutUser()
        {
            if (userLogged == null)
            {
                Console.WriteLine("Não existe nenhum usuário logado.");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine($"O usuário {userLogged.Login} foi deslogado!");
            Thread.Sleep(3000);

            userLogged = null;
        }
    }
}
