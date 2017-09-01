using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class ComisionesController : Controller
    {
        // GET: Comisiones
        public ActionResult Promotor()
        {
            return View();
        }

        public ActionResult Gerente()
        {
            return View();
        }
    }
}