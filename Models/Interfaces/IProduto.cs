using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5_CalculadoraDeDescontoComLogin.Models.Interfaces
{
    internal interface IProduto
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Brand {  get; set; }
        int Price { get; set; }
    }
}
