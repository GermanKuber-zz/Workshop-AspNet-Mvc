using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : Controller
    {

        public ActionResult Index()
        {
            return Content("Hello World!!");
        }


        public ActionResult Search(int id)
        {
            return Content($"Busco el Id numero : {id}");
        }


        [Route("greet/{nombre}")]
        public ActionResult Greet(string nombre)
        {
            return Content($"Bienvenido : {nombre}");
        }



        [Route("IsOlder/{nombre}/{apellido}/{edad}")]
        public ActionResult IsOlder(string nombre,string apellido, int edad)
        {
            bool isOlder = false;

            if (edad > 18)
                isOlder = true;

            var returnData = new ValuesViewModel
            {
                Name = nombre,
                LastName = apellido,
                IsOlder = isOlder
            };


            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        [Route("IsOlderView/{nombre}/{apellido}/{edad}")]
        public ActionResult IsOlderView(string nombre, string apellido, int edad)
        {
            bool isOlder = false;

            if (edad > 18)
                isOlder = true;

            var returnData = new ValuesViewModel
            {
                Name = nombre,
                LastName = apellido,
                IsOlder = isOlder
            };


            return View(returnData);
        }
    }


}