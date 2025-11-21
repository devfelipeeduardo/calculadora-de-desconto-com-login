using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Diagnostics;
using System.Xml.Linq;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    public class MainService : IMainService
    {
        private static IRegisterUserService _registerUserService;
        private static ILoginUserService _loginClientService;
        private static IRegisterClientService _registerClientService;
        private static IProductByClientService _productByClientService;

        public List<User> usersRegistered;
        public User userLogged;

        public List<Client> clientsRegistered;

        public MainService(IRegisterUserService registerUserService, ILoginUserService loginService,
                           IRegisterClientService registerClientService, IProductByClientService addProductByClientService)
        {
            _registerUserService = registerUserService;
            _loginClientService = loginService;
            _registerClientService = registerClientService;
            _productByClientService = addProductByClientService;


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
            Console.Write("Digite uma opção: ");
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

            var registerResult = ReturnRegisterUserResult(login, password, phoneNumber);

            if (!registerResult.Success)
            {
                Console.WriteLine("Erro no registro do usuário: ");

                foreach (var error in registerResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                }
                WaitUserToType();
            }
            if (registerResult.Success)
            {
                Console.Clear();
                Console.WriteLine($"Usuário {registerResult.Data.Login} registrado com sucesso!");
                WaitUserToType();
            }

                

        }
        public Result<User> ReturnRegisterUserResult(string login, string password, string phoneNumber)
        {
            var registerResult = _registerUserService.RegisterUser(login, password, phoneNumber, usersRegistered);

            if (registerResult.Success)
            {
                if (usersRegistered == null)
                {
                    usersRegistered = new List<User>();
                }
                usersRegistered.Add(registerResult.Data);
            }
            return registerResult;
        }

        //[2]
        public void LoginUser()
        {
            Console.WriteLine("Digite o login:");
            string login = Console.ReadLine().ToLower();
            Console.WriteLine("Digite a senha:");
            string password = Console.ReadLine();
            Console.WriteLine("Digite o telefone:");

            var loginResult = ReturnLoginUserResult(login, password);

            if (!loginResult.Success)
            {
                Console.WriteLine("Erro no registro: ");

                foreach (var error in loginResult.Errors)
                {
                    Console.WriteLine($"Erro: {error}");
                }
                WaitUserToType();
            }

            if (loginResult.Success)
            {
                Console.Clear();
                Console.WriteLine($"Usuário {loginResult.Data.Login} logado com sucesso!");
                WaitUserToType();
            }

                
        }
        public Result<User> ReturnLoginUserResult(string login, string password)
        {
            var loginResult = _loginClientService.LoginUser(login, password, userLogged, usersRegistered);

            if (loginResult.Success)
            {
                userLogged = loginResult.Data;
            }

            return loginResult;
        }

        //[3]
        public void LogoutUser()
        {
            if (!IsUserLogged()) {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
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
            ;

            Console.Clear();
            Console.WriteLine("Digite o nome do cliente:");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Digite o telefone do cliente:");
            string phoneNumber = Console.ReadLine();

            var registerResult = ReturnRegisterClientResult(name, phoneNumber);

            if (!registerResult.Success)
            {
                Console.WriteLine("Erro no registro do cliente: ");

                foreach (var error in registerResult.Errors)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: {error}");
                }
                WaitUserToType();
            }

            if (registerResult.Success)
            {
                Console.Clear();
                Console.WriteLine($"Cliente  {registerResult.Data.Name} registrado com sucesso!");
                WaitUserToType();
            } 
        }
        public Result<Client> ReturnRegisterClientResult(string name, string phoneNumber)
        {
            
            var registerResult = _registerClientService.RegisterClient(name, phoneNumber, clientsRegistered);

            if (registerResult.Success)
            {
                if (clientsRegistered == null)
                {
                    clientsRegistered = new List<Client>();
                }
                clientsRegistered.Add(registerResult.Data);
            }
            return registerResult;
        }

        //[5]
        public void ShowClients()
        {
            if (!IsUserLogged())
            {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
                WaitUserToType();
                return;
            }

            if (!IsClientRegistered()) return;

            Console.Clear();
            Console.WriteLine("Clientes e Produtos:");
            foreach (var client in clientsRegistered)
            {
                client.ShowClientData();
            }
            WaitUserToType();
        }

        //[6]
        public void AddProductsByClient()
        {
            if (!IsUserLogged())
            {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
                WaitUserToType();
                return;
            }

            if (!IsClientRegistered()) return;

            Console.Clear();

            Console.WriteLine("Digite o nome do cliente");
            string clientName = Console.ReadLine();

            bool isClientNameExistis = IsClientExistis(clientName);

            if (!isClientNameExistis)
            {
                Console.Clear();
                Console.WriteLine($"O cliente {clientName} não foi encontrado.");
                WaitUserToType();
                return;
            }

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    c.ShowClientData();
                    Console.WriteLine();

                    Console.WriteLine("Digite o nome do produto");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Digite a descrição do produto");
                    string description = Console.ReadLine();

                    Console.WriteLine("Digite a marca do produto");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto");
                    string price = (Console.ReadLine());

                    var newProductResult = ReturnAddProductsByClientResult(clientName, productName, description, brand, price);

                    if (!newProductResult.Success)
                    {
                        Console.WriteLine("Erro no registro do produto: ");

                        foreach (var error in newProductResult.Errors)
                        {
                            Console.Clear();
                            Console.WriteLine($"Erro: {error}");
                            WaitUserToType();
                        }
                    }
                    if (newProductResult.Success)
                    {
                        Console.WriteLine($"Produto adicionado com sucesso no cliente {clientName}!");
                        WaitUserToType();
                    }
                }
            }
        }
        public Result<Product> ReturnAddProductsByClientResult(string clientName, string productName, string description, string brand, string price)
        {
            var newProductResult = new Result<Product>();

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    newProductResult = _productByClientService.AddProducts(productName, description, brand, price, clientsRegistered, c.Products);

                    if (newProductResult.Success)
                    {
                        c.AddProduct(newProductResult.Data);
                        return newProductResult;
                    }

                    else if (!newProductResult.Success)
                    {
                        foreach (var error in newProductResult.Errors)
                        {

                            return newProductResult; ;
                        }
                    }
                }
            }

            return newProductResult;
        }

        //[7]
        public void DeleteProductByClient()
        {
            if (!IsUserLogged())
            {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
                WaitUserToType();
                return;
            }
            if (!IsClientRegistered()) return;

            Console.WriteLine("Digite o nome do cliente");
            string clientName = Console.ReadLine().ToLower();

            bool isClientNameExistis = IsClientExistis(clientName);

            if (!isClientNameExistis)
            {
                Console.Clear();
                Console.WriteLine($"O cliente {clientName} não foi encontrado.");
                WaitUserToType();
                return;
            }

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    c.ShowClientData();
                    Console.WriteLine();

                    Console.WriteLine("Digite o nome do produto");
                    string productName = Console.ReadLine().ToLower();

                    Result<Product> productTested = _productByClientService.IsProductOk(productName);

                    if (!productTested.Success)
                    {
                        Console.WriteLine("Erro ao excluir o produto: ");

                        foreach (var error in productTested.Errors)
                        {
                            Console.Clear();
                            Console.WriteLine($"Erro: {error}");
                            WaitUserToType();
                            return;
                        }
                    }

                    if (productTested.Success)
                    {
                        Console.WriteLine($"Produto {productTested.Data.Name}  excluído com sucesso no cliente {clientName}!");
                        WaitUserToType();
                    }
                }
            }
            Console.WriteLine($"O cliente {clientName} não foi encontrado.");
            WaitUserToType();

        }
        public Result<Product> ReturnDeleteProductByClientResult(string clientName, string productName)
        {

            var deleteProductResult = new Result<Product>();

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    Result<Product> productTested = _productByClientService.IsProductOk(productName);

                    if (productTested.Success)
                    {
                        c.DeleteProducts(productTested.Data.Name);
                        deleteProductResult = productTested;
                    }

                    else if (!productTested.Success)
                    {
                        foreach (var error in productTested.Errors)
                        {
                            deleteProductResult = productTested;
                        }
                    }
                }
            }
            return deleteProductResult;
        }

        public void CalculateTotalValueofProductsByClient()
        {
            if (!IsUserLogged())
            {
                Console.Clear();
                Console.WriteLine($"Você precista estar logado para utilizar o sistema!");
                WaitUserToType();
                return;
            }

            if (!IsClientRegistered()) return;

            Console.Clear();
            Console.WriteLine("Digite o nome do cliente");
            string clientName = Console.ReadLine();

            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    c.ShowClientData();
                    Console.WriteLine();

                    DiscountResult discountResult = ReturnCalculatedTotalValueofProductsByClientResult(clientName);

                    if (discountResult.TotalValueOfProducts <= 0)
                    {
                        Console.WriteLine("O cliente ainda não tem produtos");
                        Console.WriteLine($"O valor total dos produtos é: R$ {discountResult.TotalValueOfProducts}");
                        break;
                    }

                    Console.WriteLine($"O valor total dos produtos é: R$ {discountResult.TotalValueOfProducts}");
                    Console.WriteLine($"A porcentagem de desconto é: {discountResult.DiscountPercent} %");
                    Console.WriteLine($"O valor total dos produtos, com o desconto é: R$ {discountResult.TotalValueofProductsWithDiscount}");
                    WaitUserToType();
                }
            }



            Console.WriteLine($"O cliente {clientName} não foi encontrado.");
            WaitUserToType();
        }

        //[8]
        public DiscountResult ReturnCalculatedTotalValueofProductsByClientResult(string clientName)
        {
            foreach (var c in clientsRegistered)
            {
                if (c.Name == clientName)
                {
                    double totalValueOfProducts = c.ReturnTotalValueOfProducts();
                    double discount = c.ReturnDiscountPercent();
                    double totalValueCalculated = c.CalculateTotalValueofProductsWithDiscount();

                    var discountResult = new DiscountResult(totalValueOfProducts, discount, totalValueCalculated);
                    return discountResult;
                }
            }
            return new DiscountResult(0, 0, 0 );
        }

        //Utilitários
        public void WaitUserToType()
        {
            Console.WriteLine();
            Console.WriteLine("Aperte Enter para voltar ao menu!");
            Console.ReadKey();
        }
        public bool IsClientExistis(string clientName)
        {
            foreach (var client in clientsRegistered)
            {
                if (client.Name == clientName)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsUserLogged()
        {
            if (userLogged == null)
            {
                return false;
            }

            else { return true; }
        }

        public bool IsClientRegistered()
        {
            if (clientsRegistered == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe clientes registrados.");
                WaitUserToType();
                return false;
            }
            else { return true; }
        }

        public void WarnUserToTypeACorretOption()
        {
            Console.Clear();
            Console.WriteLine("Digiteu uma opção válida! ");
            Thread.Sleep(1000);
        }

    }
}
