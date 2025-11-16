using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Threading;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class MainService : IMainService
    {
        private static IRegisterUserService _registerUserService;
        private static ILoginUserService _loginClientService;
        private static IRegisterClientService _registerClientService;
        private static IAddProductByClientService _addProductByClientService;

        private static List<User> usersRegistered;
        private static User userLogged;

        private static List<Client> clientsRegistered;

        public MainService(IRegisterUserService registerUserService, ILoginUserService loginService,
                           IRegisterClientService registerClientService, IAddProductByClientService addProductByClientService)
        {
            _registerUserService = registerUserService;
            _loginClientService = loginService;
            _registerClientService = registerClientService;
            _addProductByClientService = addProductByClientService;


        }

        public static void ShowMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(" [1] Registrar              ");
            Console.WriteLine(" [2] Login                  ");
            Console.WriteLine(" [3] Logout                 ");
            Console.WriteLine(" [4] Cadastrar Cliente      ");
            Console.WriteLine(" [5] Relatório Clientes     ");
            Console.WriteLine(" [6] Incluir Produto        ");
            Console.WriteLine(" [7] Excluir Produto        ");
            Console.WriteLine(" [8] Calcular Desconto      ");
            Console.WriteLine("----------------------------");
        }

        //[1]
        public void RegisterUser()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");
            string phoneNumber = Console.ReadLine();

            var registerResult = _registerUserService.RegisterUser(login, password, phoneNumber, usersRegistered);

            if (!registerResult.Success)
            {
                Console.WriteLine("Erro no registro do usuário: ");

                foreach (var error in registerResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                    WaitUserToType();
                    return;
                }
            }

            if (usersRegistered == null)
            {
                usersRegistered = new List<User>();
            }

            usersRegistered.Add(registerResult.Data);
            Console.Clear();
            Console.WriteLine($"Usuário {registerResult.Data.Login} registrado com sucesso!");
            WaitUserToType();
        }
        //[2]
        public void LoginUser()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");

            var loginResult = _loginClientService.LoginUser(login, password, userLogged, usersRegistered);

            if (!loginResult.Success)
            {
                Console.WriteLine("Erro no registro: ");

                foreach (var error in loginResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                    WaitUserToType();
                    return;
                }
            }

            userLogged = loginResult.Data;

            Console.Clear();
            Console.WriteLine($"Usuário {loginResult.Data.Login} logado com sucesso!");
            WaitUserToType();
        }
        //[3]
        public void LogoutUser()
        {
            if (userLogged == null)
            {
                Console.WriteLine("Não existe nenhum usuário logado.");
                WaitUserToType();
                return;
            }

            Console.WriteLine($"O usuário {userLogged.Login} foi deslogado!");
            WaitUserToType(); ;

            userLogged = null;
        }
        //[4]
        public void RegisterClient()
        {

            if (!IsUserLogged())
            {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
                WaitUserToType();
                return;
            }

            Console.Clear();
            Console.WriteLine("Digite o nome do cliente:");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Digite o telefone do cliente:");
            string phoneNumber = Console.ReadLine();

            var registerResult = _registerClientService.RegisterClient(name, phoneNumber, clientsRegistered);

            if (!registerResult.Success)
            {
                Console.WriteLine("Erro no registro do cliente: ");

                foreach (var error in registerResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                    WaitUserToType();
                    return;
                }
            }

            if (clientsRegistered == null)
            {
                clientsRegistered = new List<Client>();
            }

            clientsRegistered.Add(registerResult.Data);
            Console.Clear();
            Console.WriteLine($"Cliente  {registerResult.Data.Name} registrado com sucesso!");
            WaitUserToType();

        }
        //[5]
        public void ShowClients()
        {
            if (clientsRegistered == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe clientes registrados.");
                WaitUserToType();
                return;
            }

            Console.Clear();
            Console.WriteLine("Clientes e Produtos:");
            foreach (var client in clientsRegistered)
            {
                client.ShowClientData();
            }
            WaitUserToType();
        }
        //[6]
        public void IncludeProductsByClient()
        {
            Console.WriteLine("Digite o nome do cliente");
            string clientName = Console.ReadLine();

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    Console.WriteLine("Digite o nome do produto");
                    string name = Console.ReadLine();
                    Console.WriteLine("Digite a descrição do produto");
                    string description = Console.ReadLine();

                    Console.WriteLine("Digite a marca do produto");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto");
                    double price = double.Parse(Console.ReadLine());

                    var newProduct = 

                    c.IncludeProducts();
                }
            }
        }


        //Utilitários
        public void WaitUserToType()
        {
            Console.WriteLine();
            Console.WriteLine("Aperte Enter para voltar ao menu!");
            Console.ReadKey();
        }

        public bool IsUserLogged()
        {
            if (userLogged == null)
            {
                return false;
            }
            else { return true; }
        }
    }
}
