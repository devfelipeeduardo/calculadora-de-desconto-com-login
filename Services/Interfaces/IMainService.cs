using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IMainService
    {
        static IRegisterUserService _registerService;
        static ILoginUserService _loginService;
        static List<User> usersRegistered;
        static User userLogged;
        static List<Client> clientsRegistered;

        void RegisterUser();
        void LoginUser();
        void LogoutUser();
    }
}
