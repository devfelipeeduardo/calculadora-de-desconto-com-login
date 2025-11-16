using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IRegisterUserService
    {
        Result<User> RegisterUser(string login, string password, string phoneNumber, List<User> usersRegistered);
    }
}
