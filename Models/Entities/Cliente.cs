using Fase5_CalculadoraDeDescontoComLogin.Models.Interfaces;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities
{
    internal class Client : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; } //Vou tentar utilizar REGEX + DTO no endpoint para tratar o telefone.
    }
}
