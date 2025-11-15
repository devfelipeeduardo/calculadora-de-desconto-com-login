using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Data;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class LoginService : ILoginService
    {
        public LoginService() { }

        public Result<Client> LoginClient(string login, string password, Client clientLogged, List<Client> clientsRegistered)
        {
            var errors = new List<string>();

            //Login
            if (string.IsNullOrWhiteSpace(login))
            {
                errors.Add($"O login: {login} não pode ser nulo ou vazio.");
            }

            if (login.Length < 6)
            {
                errors.Add($"O login: {login} deve ser maior que 6 dígitos");
            }

            if (login.Length > 15)
            {
                errors.Add($"O login {login} não pode ter mais de 15 caracteres");
            }
            if (errors.Count > 0) return Result<Client>.Fail(errors.ToArray());


            //Senha
            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add($"A senha não pode ser nula ou igual a 0.");
            }

            if (password.Length < 8)
            {
                errors.Add($"A senha precisa ser igual ou maior a 8 dígitos");
            }

            if (clientLogged != null) { 
                if (login == clientLogged.Login)
                {
                    errors.Add($"O login {login} já está logado!");
                }
            }

            if (clientsRegistered == null)
            {
                errors.Add($"O login {login} ainda não foi registrado!");
            }

            if (clientsRegistered != null) {
                foreach (var clientRegistered in clientsRegistered) {
                    if (login == clientRegistered.Login && password == clientRegistered.Password)
                    {
                        continue;
                    }
                    errors.Add($"O login {login} ainda não foi registrado!");
                }
            }

            if (errors.Count > 0) return Result<Client>.Fail(errors.ToArray());

            var client = new Client
            {
                Login = login,
                Password = password
            };

            return Result<Client>.Ok(client); ;
        }
    }
}
