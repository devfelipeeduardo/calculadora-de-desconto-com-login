using Fase5_CalculadoraDeDescontoComLogin.Services;
using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Unity;
using Fase5_CalculadoraDeDescontoComLogin.Interfaces;
using System.ComponentModel;

namespace Fase5.Calculadora
{
    class Program
    {
        public static Client Client { get; set; }
        public static void Main(string[] args)
        {
            var registerContainer = RegisterDependencies(new UnityContainer());
            IRegisterService registerService = registerContainer.Resolve<IRegisterService>();

            Console.WriteLine("------------------");
            Console.WriteLine("    Calculadora   ");
            Console.WriteLine("    de Desconto   ");
            Console.WriteLine("------------------");

            while(true)
            {
                Console.WriteLine("Registre um usuário: ");
                Console.Write("Digite seu login: ");
                string login = Console.ReadLine();
                Console.Write("Senha: ");
                string password = Console.ReadLine();

                Console.Write("Telefone: ");
                string phoneNumber = Console.ReadLine();

                Client = registerService.Registrar(login, password, phoneNumber);

                Client.ShowClientData();
            }
        }

        public static UnityContainer RegisterDependencies(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IRegisterService, RegisterService>();
            return unityContainer;
        }
    }
}