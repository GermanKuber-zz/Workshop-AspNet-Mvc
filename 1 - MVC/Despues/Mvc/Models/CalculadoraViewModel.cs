using System.Collections.Generic;
using Mvc.Controllers;

namespace Mvc.Models
{
    public class CalculadoraViewModel
    {
        public List<int> Numeros { get; set; }
        public OperacionEnum Operacion { get; set; }
        public int Resultado { get; set; }
    }
}