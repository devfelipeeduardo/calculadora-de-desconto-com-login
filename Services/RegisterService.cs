using Fase5_CalculadoraDeDescontoComLogin.Interfaces;
using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class RegisterService : IRegisterService
    {

        public RegisterService() {}   
        public Client Registrar(string login, string password, string phoneNumber)
        {
                if (login == null || login.Length == 0)
                {
                    Console.WriteLine($"O login: {login} não pode ser nulo ou igual a 0.");
                }

                if (login.Length < 6)
                {
                    Console.WriteLine($"O login: {login} deve ser maior que 6 dígitos");
                }

                if (login.Length > 15)
                {
                    Console.WriteLine($"O login {login} não pode ter mais de 15 caracteres");
                }

                //Senha
                if (password == null || password.Length == 0)
                {
                    Console.WriteLine($"A senha não pode ser nula ou igual a 0.");
                }

                if (password.Length < 8)
                {
                    Console.WriteLine($"A senha precisa ser igual ou maior a 8 dígitos");
                }

                Thread.Sleep(2000);
                Console.Clear();

                string role = "usuario";

                Client newUser = new Client { Login = login,
                                                Password = password,
                                                PhoneNumber = phoneNumber,
                                                Role = role
                };

                return newUser;
            }
        }
    }
