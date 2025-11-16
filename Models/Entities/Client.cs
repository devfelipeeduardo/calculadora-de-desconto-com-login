using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    internal class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product> Products { get; set; } = new List<Product> {

        new Product(1, "lápis", "lápis de escrever", "fabercastell", 1.50),
        new Product(2, "caneta", "caneta esferográfica", "bic", 2.50)

    };

        public Client() { }
        public void ShowClientData()
        {
            Console.WriteLine($"Nome: {Name}\n" +
                              $"Tel: {PhoneNumber}");
            ShowClientProducts();
        }

        public void ShowClientProducts()
        {
            foreach (Product product in Products)
            {
                var stringProduto = product.ToString();
                Console.WriteLine(stringProduto);
            }
        }
    }
}
