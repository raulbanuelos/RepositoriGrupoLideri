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
        public ActionResult GuardarPersona(int idJerarquia, string usuario, string contrasena,
            string nombre,string aPaterno,string aMaterno,string fechaNacimiento,string rfc,string matricula,int idGerentePromotor,
            string area,string estrategia,int activo)
        {
            DO_Persona usuarioLogueado = (DO_Persona)Session["UsuarioConectado"];
            DataManager.InsertOrUptadeOrDeletePersona(idJerarquia, usuario, contrasena, nombre,
                aPaterno, aMaterno, fechaNacimiento, rfc, matricula, idGerentePromotor, area, estrategia, activo, 1, "admin");


            return RedirectToAction("Index", "Persona");

        }

    }
}