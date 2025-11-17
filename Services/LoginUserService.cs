using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Data;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class LoginUserService : ILoginUserService
    {
        public LoginUserService() { }

        public Result<User> LoginUser(string login, string password, User userLogged, List<User> usersRegistered)
        {
            var errors = new List<string>();

            //Login
            if (string.IsNullOrWhiteSpace(login))
            {
                errors.Add($"O login não pode ser nulo ou vazio.");
            }

            if (login.Length < 6)
            {
                errors.Add($"O login deve ser maior que 6 dígitos");
            }

            if (login.Length > 15)
            {
                errors.Add($"O login não pode ter mais de 15 caracteres");
            }
            if (errors.Count > 0) return Result<User>.Fail(errors.ToArray());


            //Senha
            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add($"A senha não pode ser nula ou igual a 0.");
            }

            if (password.Length < 8)
            {
                errors.Add($"A senha precisa ser igual ou maior a 8 dígitos");
            }

            if (userLogged != null)
            {
                if (login == userLogged.Login)
                {
                    errors.Add($"O login {login} já está logado!");
                }
            }

            if (usersRegistered == null)
            {
                errors.Add($"O login {login} ainda não foi registrado!");
            }

            if (usersRegistered != null)
            {
                Console.WriteLine(usersRegistered.ToString());
                foreach (var userRegistered in usersRegistered)
                {
                    if (login == userRegistered.Login && password == userRegistered.Password)
                    {
                        break;
                    }
                    errors.Add($"O login {login} e/ou senha estão incorretos.!");
                }
            }

            if (errors.Count > 0) return Result<User>.Fail(errors.ToArray());

            var user = new User
            {
                Login = login,
                Password = password
            };

            return Result<User>.Ok(user); ;
        }
    }
}
