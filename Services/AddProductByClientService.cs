using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    internal class AddProductByClientService : IAddProductByClientService
    {
        public Result<Product> AddProducts(string name, string description, string brand, double price,
                                           List<Client> clientsRegistered) {

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name)){
                errors.Add($"O cliente não existe. ");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"O nome do cliente não pode ser nulo ou vazio.");
            }

            if (name.Length < 6)
            {
                errors.Add($"O nome do cliente deve ser maior que 6 dígitos");
            }

            if (name.Length > 15)
            {
                errors.Add($"O nome do cliente não pode ter mais de 15 caracteres");
            }

            if (errors.Count > 0) return Result<Product>.Fail(errors.ToArray());

            return new Result<Product>();
        }
    }
}
