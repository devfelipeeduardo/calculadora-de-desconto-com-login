namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }

        public Product(int id, string name, string description, string brand, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Brand = brand;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | Description: {Description} | Brand: {Brand} | Price: {Price}";
        }
    }
}
