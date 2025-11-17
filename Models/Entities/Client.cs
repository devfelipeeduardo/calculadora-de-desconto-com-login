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
            ShowClientProducts();
            Products.RemoveAll(p => p.Name.Contains(productName));
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

        private double ReturnDiscountPercent()
        {
            if (Products.Count == 2)
            {
                return 0.10;
            }

            else if (Products.Count > 2)
            {
                return 0.20;
            }

            return 0;
        }
    }
}
