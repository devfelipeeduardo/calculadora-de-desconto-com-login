using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Interfaces
{
    internal interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        int PhoneNumber { get; set; }
    }
}
