using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using Fase5_CalculadoraDeDescontoComLogin.Models.Models;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    public interface IRegisterUserService
    {
        Result<User> RegisterUser(string login, string password, string phoneNumber, List<User> usersRegistered);
    }
}
