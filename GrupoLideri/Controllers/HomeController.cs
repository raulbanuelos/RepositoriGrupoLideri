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

        #region GERENTES-PROMOTORES
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
        public JsonResult CargarResumenComisionGerente(string paramentro)
        {
            double totalComision = 0;

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(3) || usuarioConectado.idJerarquia.Equals(4))
            {
                totalComision = DataManagerLideri.GetComisionGerenteTotal(usuarioConectado.idPersona);
            }

            return Json(totalComision);
        }

        [HttpPost]
        public JsonResult CargarCantidadVentaGerente(string paramentro)
        {
            int foliosVendidos = 0;

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(3) || usuarioConectado.idJerarquia.Equals(4))
            {
                foliosVendidos = DataManagerLideri.GetFoliosVendidosGerente(usuarioConectado.idPersona);
            }

            return Json(foliosVendidos);
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

        [HttpPost]
        public JsonResult CargarPosteadosVSProduccionGerente(string paramentros)
        {
            double pct = 0;

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            string fechaInicial = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            string fechaFinal = endDate.Day + "/" + endDate.Month + "/" + endDate.Year;

            if (usuarioConectado.idJerarquia.Equals(3) || usuarioConectado.idJerarquia.Equals(4))
            {
                pct = DataManagerLideri.GetPosteadosVSProduccionGerente(usuarioConectado.idPersona, fechaInicial, fechaFinal);
            }

            double noPosteados = 100.0 - pct;
            List<FO_Item_Paquete> l = new List<FO_Item_Paquete>();
            l.Add(new FO_Item_Paquete { label = "Posteados", value = pct });
            l.Add(new FO_Item_Paquete { label = "No posteados", value = noPosteados });


            return Json(l);
        }

        [HttpPost]
        public JsonResult CargarPosteadosVSProduccionPromotor(string fechaInicial, string fechaFinal)
        {
            double pct = 0;

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(1) || usuarioConectado.idJerarquia.Equals(2))
            {
                pct = DataManagerLideri.GetPosteadosVSProduccionPromotor(usuarioConectado.idPersona, fechaInicial, fechaFinal);
            }

            return Json(pct);
        }
        #endregion

        #region NOMINAS

        public JsonResult CargarResumenNomina(string parametro)
        {
            double pagoNomina = 0;

            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            if (usuarioConectado.idJerarquia.Equals(7))
            {
                pagoNomina = DataManagerLideri.GetNominaComisionesResumen();
            }

            return Json(pagoNomina);
        }

        #endregion

        public ActionResult CerrarSession()
        {
            Session.Abandon();

            return RedirectToAction("Index", "LogIn");
        }
    }
}