using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    public interface ILoginUserService
    {
        Result<User> LoginUser(string login, string password, User userLogged, List<User> usersRegistered);
    }
}
