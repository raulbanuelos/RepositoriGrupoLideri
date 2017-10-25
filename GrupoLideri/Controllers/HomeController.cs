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
        public JsonResult CargarPaquetesVendidos(string parametro)
        {
            List<FO_Item_Paquete> paquetes = new List<FO_Item_Paquete>();

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(1) || usuarioConectado.idJerarquia.Equals(2) || usuarioConectado.idJerarquia.Equals(3) || usuarioConectado.idJerarquia.Equals(4))
            {
                paquetes = DataManagerLideri.GetPaquetesGerente(usuarioConectado.idPersona);

                var jsonResult = Json(paquetes, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
            }
            
            return Json(paquetes);
        }

        [HttpPost]
        public JsonResult CargarHistorialNominas(string parametro)
        {
            List<double> historialComision = new List<double>();

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(1) || usuarioConectado.idJerarquia.Equals(2) || usuarioConectado.idJerarquia.Equals(3) || usuarioConectado.idJerarquia.Equals(4))
            {
                historialComision = DataManagerLideri.GetHistorialNominaPersona(usuarioConectado.idPersona);

                var jsonResult = Json(historialComision, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
            }

            return Json(historialComision);
        }

        public ActionResult CerrarSession()
        {
            Session.Abandon();

            return RedirectToAction("Index", "LogIn");
        }
    }
}