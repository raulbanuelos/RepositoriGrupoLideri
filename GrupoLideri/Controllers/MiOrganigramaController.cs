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
    }
}