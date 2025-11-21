using Fase5_CalculadoraDeDescontoComLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    public interface IMainService
    {
        static IRegisterUserService _registerService;
        static ILoginUserService _loginService;
        static List<User> usersRegistered;
        static User userLogged;
        static List<Client> clientsRegistered;

        void RegisterUser();
        void LoginUser();
        void LogoutUser();
        void RegisterClient();
        void ShowClients();
        void AddProductsByClient();
        void DeleteProductByClient();
        void CalculateTotalValueofProductsByClient();
        void WarnUserToTypeACorretOption();
    }
}
