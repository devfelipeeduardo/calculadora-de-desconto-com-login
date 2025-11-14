using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Interfaces
{
    internal interface IRegisterService
    {
        Client Registrar(string login, string password, string phoneNumber);
    }
}
