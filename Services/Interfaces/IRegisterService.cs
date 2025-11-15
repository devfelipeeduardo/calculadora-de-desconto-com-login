using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IRegisterService
    {
        Result<Client> RegisterClient(string login, string password, string phoneNumber, List<Client> clientsRegistered);
    }
}
