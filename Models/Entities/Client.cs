namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

internal class Client
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }
    public bool IsLogged { get; set; }
    public List<Product> Products { get; set; } = new List<Product> { 
    
        new Product(1, "lápis", "lápis de escrever", "fabercastell", 1.50),
        new Product(2, "caneta", "caneta esferográfica", "bic", 2.50)
    
    };

    public Client() { }
    public void ShowClientData()
    {
        Console.WriteLine($"Login: {Login}\n" +
                          $"Acesso: {Role}\n" +
                          $"Tel: {PhoneNumber}");

        ShowProducts();
    }

    public void ShowProducts()
    {
        foreach (Product product in Products)
        {
            var stringProduto = product.ToString();
            Console.WriteLine(stringProduto);
        }
    }
}
