using Fase5_CalculadoraDeDescontoComLogin.Models.Interfaces;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    internal class Produto : IProduto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
