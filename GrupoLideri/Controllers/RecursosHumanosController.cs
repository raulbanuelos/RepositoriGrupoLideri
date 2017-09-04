using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class RecursosHumanosController : Controller
    {
        #region AsignarMatricula
        // GET: RecursosHumanos
        public ActionResult AsignarClavePromotor()
        {

            List<DO_Persona> ListaPersona = new List<DO_Persona>();

            ListaPersona = DataManagerLideri.GetPersonaPendienteClavePromotor();

            ViewBag.ListaPersonasPorAsignarCve = ListaPersona;

            return View();
        }

        public JsonResult AsignarClave(int idUsuario, string cvePromotor)
        {
            if (!DataManagerLideri.ExistsMatricula(cvePromotor))
            {
                int respuesta = DataManagerLideri.AsignarCvePromotor(idUsuario, cvePromotor);

                if (respuesta > 0)
                    return Json("Los datos fueron guardados correctamente, se le notificará por correo al usuario.");
                else
                    return Json("Upps! hubo algún error, favor de intentar mas tarde.");
            }
            else
                return Json("La clave promotor ya existe, favor ingrese otra");

        }
        #endregion
    }
}