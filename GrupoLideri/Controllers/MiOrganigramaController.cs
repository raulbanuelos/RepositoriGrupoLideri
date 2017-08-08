using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class MiOrganigramaController : Controller
    {
        // GET: MiOrganigrama
        [GrupoLideriVerificarRol]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrganigrama(string campo)
        {

            List<DO_Item_Chart> Lista = new List<DO_Item_Chart>();

            DO_Persona usuario = (DO_Persona)Session["UsuarioConectado"];

            Lista = DataManager.GetOrganigrama(usuario.idPersona);

            var jsonResult = Json(Lista, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;


        }
    }
}