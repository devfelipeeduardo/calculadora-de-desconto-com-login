using Fase5_CalculadoraDeDescontoComLogin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Services.Interfaces
{
    internal interface IRegisterClientService
    {
        public Result<Client> RegisterClient(string name, string phoneNumber, List<Client> clientsRegistered);
    }
}
