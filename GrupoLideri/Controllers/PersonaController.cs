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
            List<FO_Item_Combo> ListaPersonas = DataManagerLideri.GetPersonas();

            ListaPersonas =  ListaPersonas.OrderBy(x => x.Text).ToList();
            
            List<SelectListItem> Participantes = DataManagerLideri.ToDropdownListFromItemCombo(ListaPersonas);
            
            return Json(new SelectList(Participantes, "Value", "Text"));
        }

        public JsonResult CargarJerarquias(string parametro)
        {
            List<FO_Item_Combo> ListaJerarquias = DataManagerLideri.GetJearaquias();

            List<SelectListItem> Jerarquias = DataManagerLideri.ToDropdownListFromItemCombo(ListaJerarquias);

            return Json(new SelectList(Jerarquias, "Value", "Text"));
        }

        [HttpPost]
        public JsonResult InsertPersona(string aMaterno, string aPaterno, string contrasena, string email, string fechaNacimiento, int idJefe, int idJerarquia,string matricula,string nombre,string rfc, string telefono, string usuario)
        {
            int respuesta = DataManagerLideri.InsertUsuario(aMaterno, aPaterno, contrasena, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, matricula, nombre, rfc, telefono, usuario);
            
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem { Text = respuesta.ToString(), Value = respuesta.ToString() });


            return Json(new SelectList(lista, "Value", "Text"));
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