using Unity;
using Fase5_CalculadoraDeDescontoComLogin.Services;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;

namespace Fase5.Calculadora
{
    class Program
    {

        public static void Main(string[] args)
        {
            var container = RegisterDependencies(new UnityContainer());

            var mainService = new MainService(
                container.Resolve<IRegisterUserService>(),
                container.Resolve<ILoginUserService>(),
                container.Resolve<IRegisterClientService>(),
                container.Resolve<IProductByClientService>()
                );

            while (true)
            {
                Console.Clear();
                MainService.ShowMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        mainService.RegisterUser();
                        break;
                    case "2":
                        Console.Clear();
                        mainService.LoginUser();
                        break;
                    case "3":
                        Console.Clear();
                        mainService.LogoutUser();
                        break;
                    case "4":
                        mainService.RegisterClient();
                        Console.Clear();
                        break;
                    case "5":
                        mainService.ShowClients();
                        Console.Clear();
                        break;
                    case "6":
                        mainService.AddProductsByClient();
                        Console.Clear();
                        break;
                    case "7":
                        mainService.DeleteProductByClient();
                        Console.Clear();
                        break;
                    case "8":
                        mainService.CalculateTotalValueofProductsByClient();
                        Console.Clear();
                        break;
                }
            }
        }

        //Pedro me ensinou a registrar as classes que herdam das services para facilitar testes.
        public static UnityContainer RegisterDependencies(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IRegisterUserService, RegisterUserService>();
            unityContainer.RegisterType<ILoginUserService, LoginUserService>();
            unityContainer.RegisterType<IRegisterClientService, RegisterClientService>();
            unityContainer.RegisterType<IProductByClientService, ProductByClientService>();
            return unityContainer;
        }
    }
}