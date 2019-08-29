using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdvogadosOab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult BuscaAdvogado(string inscricao, string uf, string nome)
        {
            var retorno = AdvogadoAdapter.ConsultaAdvogado(inscricao, uf, nome);

            JsonResult jsonResult = Json(retorno, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

    }
}