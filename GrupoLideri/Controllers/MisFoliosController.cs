using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class MisFoliosController : Controller
    {
        // GET: MisFolios
        [GrupoLideriVerificarRol]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscarFolios(string fechaIncial, string fechaFinal, int IsPosteada)
        {
            DO_Persona usuario = (DO_Persona)Session["UsuarioConectado"];

            List<N_Folio_SIAC> ListaFolios = DataManager.GetFoliosPromotor(fechaIncial, fechaFinal, usuario.idPersona, IsPosteada);

            var jsonResult = Json(ListaFolios, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }
    }
}