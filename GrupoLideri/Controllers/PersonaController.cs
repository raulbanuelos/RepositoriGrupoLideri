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

            ListaPersonas =  ListaPersonas.OrderBy(x => x.Text).ToList();

            //Convertimos la lista FO_ItemCombo lista de tipo SelectListItem.
            List<SelectListItem> Participantes = DataManager.ToDropdownListFromItemCombo(ListaPersonas);
            
            return Json(new SelectList(Participantes, "Value", "Text"));
        }

        [HttpPost]
        public ActionResult InsertPersona(string aMaterno, string aPaterno, string contrasena, string email, string fechaNacimiento, int idJefe, int idJerarquia,string matricula,string nombre,string rfc, string telefono, string usuario)
        {
            int respuesta = DataManagerLideri.InsertUsuario(aMaterno, aPaterno, contrasena, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, matricula, nombre, rfc, telefono, usuario);

            return RedirectToAction("Index", "Persona");
        }

        [HttpPost]
        public ActionResult UpdatePersona(string aMaterno, string aPaterno, string contrasena, string email, string fechaNacimiento, int idJefe, int idJerarquia, string matricula, string nombre, string rfc, string telefono, string usuario, int idUsuario)
        {
            int respuesta = DataManagerLideri.UpdateUsuario(aMaterno, aPaterno, contrasena, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, matricula, nombre, rfc, telefono, usuario, idUsuario);

            return RedirectToAction("Index", "Persona");
        }

        [HttpPost]
        public ActionResult DeletePersona(int idUsuario)
        {
            int respuesta = DataManagerLideri.DeleteUsuario(idUsuario);

            return RedirectToAction("Index", "Persona");
        }

    }
}