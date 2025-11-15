using Fase5_CalculadoraDeDescontoComLogin.Services;
using Unity;
using Fase5_CalculadoraDeDescontoComLogin.Interfaces;

namespace Fase5.Calculadora
{
    class Program
    {

        public static void Main(string[] args)
        {
            var container = RegisterDependencies(new UnityContainer());

            var mainService = new MainService(container.Resolve<IRegisterService>());


            while (true) {
                Console.Clear();
                MainService.ShowMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        mainService.Register();
                        break;
                }

            }
        }

        //Pedro me ensinou a registrar as classes que herdam das services para facilitar testes.
        public static UnityContainer RegisterDependencies(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IRegisterService, RegisterService>();
            return unityContainer;
        }
    }
}