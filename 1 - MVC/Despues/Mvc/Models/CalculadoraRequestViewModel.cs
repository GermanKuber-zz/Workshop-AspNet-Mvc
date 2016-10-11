using Mvc.Controllers;

namespace Mvc.Models
{
    public class CalculadoraRequestViewModel
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public OperacionEnum Operacion { get; set; }
    }
}