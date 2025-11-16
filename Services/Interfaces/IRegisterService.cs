using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IRegisterService
    {
        Result<User> RegisterUser(string login, string password, string phoneNumber, List<User> usersRegistered);
    }
}
