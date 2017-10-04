using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class NominasController : Controller
    {
        // GET: Nominas
        public ActionResult NominaComisiones()
        {
            List<N_Folio_SIAC> listaNomina = new List<N_Folio_SIAC>();

            listaNomina = DataManagerLideri.GetNominaComisiones();

            ViewBag.ListaNominaComision = listaNomina;

            return View();
        }
    }
}