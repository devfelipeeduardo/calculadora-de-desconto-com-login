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
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product> Products { get; set; } = new List<Product> {

            //Teste
            //new Product{
            //    Name ="lápis",
            //    Description = "lápis de escrever",
            //    Brand = "fabercastell",
            //    Price = 1.50
            //}
        
        };

        public Client() { }

        public void ShowClientData()
        {
            Console.WriteLine($"Nome: {Name}\n" +
                              $"Tel: {PhoneNumber}");
            ShowClientProducts();
        }

        public void AddProducts(Product product) {

            Products.Add(product);
        }

        public void DeleteProducts(string productName)
        {
            foreach (Product product in Products) {
                if (productName == product.Name) {
                    Products.Remove(product);
                }
            }
        }

        private void ShowClientProducts()
        {
            if (Products == null )
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
