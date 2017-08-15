using GrupoLideri.Models;
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


        public JsonResult CargarPersonas(string parametro)
        {
            DO_Persona usuario = (DO_Persona)Session["UsuarioConectado"];

            List<FO_Item_Combo> ListaPersonas = DataManager.GetPersonas(usuario.idPersona);

            //Convertimos la lista FO_ItemCombo lista de tipo SelectListItem.
            List<SelectListItem> Participantes = DataManager.ToDropdownListFromItemCombo(ListaPersonas);

            Participantes  = Participantes.OrderBy(x => x.Text).ToList();

            return Json(new SelectList(Participantes, "Value", "Text"));
        }
    }
}