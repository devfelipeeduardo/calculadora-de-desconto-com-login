namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    public class Client
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

        public void AddProduct(Product product)
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

        public double CalculateTotalValueofProductsWithDiscount()
        {
            double discountPercent = ReturnDiscountPercent();
            double totalValueOfProducts = ReturnTotalValueOfProducts();

            Console.WriteLine(discountPercent);
            return discountPercent * totalValueOfProducts;
        }

        public double ReturnTotalValueOfProducts()
        {
            if (Products.Count == 0) return 0;

            double total = 0;
            foreach (var p in Products) {
                total += p.Price;
            }
            return total;
        }

        public double ReturnDiscountPercent()
        {
            if (Products.Count == 2) return 10/100;
            else if (Products.Count > 2) return 20/100;
            else return 0;
        }
    }
}
