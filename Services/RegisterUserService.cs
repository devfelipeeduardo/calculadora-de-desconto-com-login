using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        public RegisterUserService() { }
        public Result<User> RegisterUser(string login, string password, string phoneNumber, List<User> usersRegistered)
        {
            //Aqui eu tentei validar alguns casos que eu acho que podem ser legais de avaliar no teste, mas acredito q tenha algum tipo de padrão
            //de conferência, até mesmo usando DataAnottations nas models.
            var errors = new List<string>();

            //Login
            if (string.IsNullOrWhiteSpace(login))
            {
                errors.Add($"O login: não pode ser nulo ou vazio.");
            }

            if (login.Length < 6)
            {
                errors.Add($"O login: deve ser maior que 6 dígitos");
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

            //Telefone
            if (phoneNumber.Length != 11)
            {
                errors.Add($"O telefone deve conter 11 números");
            }

            if (usersRegistered != null)
            {
                foreach (var userRegistered in usersRegistered)
                {
                    if (login == userRegistered.Login)
                    {
                        errors.Add($"O login {login} já existe!");
                    }
                }
            }

            if (errors.Count > 0) return Result<User>.Fail(errors.ToArray());

            string role = "usuario";
            var newUser = new User
            {
                Login = login,
                Password = password,
                PhoneNumber = phoneNumber,
                Role = role,
            };

            return Result<User>.Ok(newUser);
        }
    }
}