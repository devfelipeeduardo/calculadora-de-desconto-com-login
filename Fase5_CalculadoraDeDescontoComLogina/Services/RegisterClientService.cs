using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    public class RegisterClientService : IRegisterClientService
    {
        public RegisterClientService() { }

        public Result<Client> RegisterClient(string name, string phoneNumber, List<Client> clientsRegistered)
        {
            var errors = new List<string>();

            //Login
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"O cliente não pode ter o nome nulo ou vazio.");
            }

            if (name.Length > 50)
            {
                errors.Add($"O nome do cliente não pode ter mais de 50 caracteres");
            }

            //Telefone
            if (phoneNumber.Length != 11)
            {
                errors.Add($"O telefone deve conter 11 números");
            }

            if (clientsRegistered != null)
            {
                foreach (var clientRegistered in clientsRegistered)
                {
                    if (name == clientRegistered.Name)
                    {
                        errors.Add($"O cliente {name} já existe!");
                    }
                }
            }

            if (errors.Count > 0) return Result<Client>.Fail(errors.ToArray());

            var newClient = new Client
            {
                Name = name,
                PhoneNumber = phoneNumber
            };

            return Result<Client>.Ok(newClient);
        }
    }
}
