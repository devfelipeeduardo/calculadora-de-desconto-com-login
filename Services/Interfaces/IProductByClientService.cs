using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IProductByClientService
    {
        Result<Product> AddProducts(string name, string description, string brand, double price,
                                    List<Client> clientsRegistered, List<Product> productsAdded);

        Result<Product> IsProductOk(string name);
    }
}
