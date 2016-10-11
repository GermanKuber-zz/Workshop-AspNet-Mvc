using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class CalculadoraController : Controller
    {

        [HttpGet]
        public ActionResult Operar()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Operar(CalculadoraRequestViewModel model)
        {
            var returnData = new CalculadoraViewModel();


            switch (model.Operacion)
            {
                case OperacionEnum.Suma:
                    returnData.Resultado = model.Numero1 + model.Numero2;
                    break;
                case OperacionEnum.Resta:
                    returnData.Resultado = model.Numero1 - model.Numero2;
                    break;
                case OperacionEnum.Multiplicacion:
                    returnData.Resultado = model.Numero1 * model.Numero2;
                    break;
                case OperacionEnum.Division:
                    if (model.Numero2 != 0)
                    {
                        returnData.Resultado = model.Numero1 / model.Numero2;
                    }
                    else
                    {
                        return RedirectToAction("Error",new  { s =  "No se puede dividir por cero"});
                    }
                    break;

            }



            return View("OperarResult",returnData);
        }

        public ActionResult Error(string s)
        {
            return View(new ErrorViewModel { Error = s });
        }
    }
}