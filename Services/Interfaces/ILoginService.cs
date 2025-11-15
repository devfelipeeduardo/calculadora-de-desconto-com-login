using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface ILoginService
    {
        Result<Client> LoginClient(string login, string password, Client clientLogged, List<Client> clientsRegistered);
    }
}
