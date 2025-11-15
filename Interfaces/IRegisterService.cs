using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Interfaces
{
    internal interface IRegisterService
    {
        Result<Client> Register(string login, string password, string phoneNumber, List<Client> clientsRegistered);
    }
}
