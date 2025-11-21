namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }

        public Product() { }

        public override string ToString()
        {
            return $"Nome: {Name} | Descrição: {Description} | Marca: {Brand} | Preço: R$ {Price}";
        }
    }
}
