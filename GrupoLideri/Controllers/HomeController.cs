using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class HomeController : Controller
    {
        [GrupoLideriVerificarRol]
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

        [HttpPost]
        public JsonResult CargarPaquetesVendidos(string fechaInicial,string fechaFinal)
        {
            List<FO_Item_Paquete> paquetes = new List<FO_Item_Paquete>();

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            paquetes = DataManagerLideri.GetPaquetesGerente(usuarioConectado.idPersona,fechaInicial, fechaFinal);

            var jsonResult = Json(paquetes, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return Json(new SelectList(paquetes, "value", "label"));
        }
    }
}