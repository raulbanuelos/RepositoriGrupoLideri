using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        [GrupoLideriVerificarRol]
        public ActionResult Index()
        {
            return View();
        }
    }
}