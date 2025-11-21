using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces;
using System.Diagnostics;

namespace Fase5_CalculadoraDeDescontoComLogin.Services
{
    public class ProductByClientService : IProductByClientService
    {
        public Result<Product> AddProducts(string name, string description, string brand, string price,
                                           List<Client> clientsRegistered, List<Product> productsRegistered)
        {

            var errors = new List<string>();

            if (!double.TryParse(price, out double priceParsed))
            {
                errors.Add($"O preço precisa ser decimal.");
            }

            //Nome
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"O nome do produto não pode ser nulo ou vazio.");
            }
            if (name.Length > 50)
            {
                errors.Add($"O nome do produto não pode ter mais de 50 caracteres");
            }

            //Descrição
            if (string.IsNullOrWhiteSpace(description))
            {
                errors.Add($"A descrição do produto não pode ser nula ou vazia.");
            }
            if (description.Length < 6)
            {
                errors.Add($"A descrição do produto deve ser maior que 6 dígitos");
            }
            if (description.Length > 100)
            {
                errors.Add($"A descrição do produto não pode ter mais de 100 caracteres");
            }

            //Marca
            if (string.IsNullOrWhiteSpace(brand))
            {
                errors.Add($"A marca do produto não pode ser nula ou vazia.");
            }

            if (brand.Length > 100)
            {
                errors.Add($"A marca do produto não pode ter mais de 100 caracteres");
            }

            //Preço

            if (priceParsed == 0.0)
            {
                errors.Add($"O produto não pode ter o preço zerado.");
            }

            if (productsRegistered != null)
            {
                foreach (var p in productsRegistered)
                {
                    if (name == p.Name)
                    {
                        errors.Add($"O produto {name} já existe.");
                    }
                }
            }

            if (errors.Count > 0) return Result<Product>.Fail(errors.ToArray());

            var newProduct = new Product
            {
                Name = name,
                Description = description,
                Brand = brand,
                Price = priceParsed,
            };

            return Result<Product>.Ok(newProduct);
        }

        public Result<Product> IsProductOk(string name)
        {
            var errors = new List<string>();

            //Nome
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add($"O nome do produto não pode ser nulo ou vazio.");
            }
            if (name.Length < 6)
            {
                errors.Add($"O nome do produto deve ser maior que 6 dígitos");
            }
            if (name.Length > 15)
            {
                errors.Add($"O nome do produto não pode ter mais de 15 caracteres");
            }

            if (errors.Count > 0) return Result<Product>.Fail(errors.ToArray());

            var productTested = new Product
            {
                Name = name
            };

            return Result<Product>.Ok(productTested);
        }
    }
}
