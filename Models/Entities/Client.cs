using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    internal class Client
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();

        public void ShowClientData()
        {
            Console.WriteLine($"Nome: {Name}\n" +
                              $"Tel: {PhoneNumber}");
            ShowClientProducts();
        }

        public void AddProducts(Product product)
        {
            Products.Add(product);
        }

        public void DeleteProducts(string productName)
        {
            foreach (Product product in Products)
            {
                if (productName == product.Name)
                {
                    Products.Remove(product);
                }
            }
        }

        private void ShowClientProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("Cliente ainda não tem produtos.");
                return;
            }

            foreach (Product product in Products)
            {
                var stringProduto = product.ToString();
                Console.WriteLine(stringProduto);
            }
        }
    }
}
