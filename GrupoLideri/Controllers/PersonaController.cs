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

        #region AsignarMatricula
        public ActionResult AsignarMatricula()
        {
            return View();
        } 

        public JsonResult GetPersonasPendienteClavePromotor()
        {
            List<DO_Persona> ListaPersona = new List<DO_Persona>();

            ListaPersona = DataManagerLideri.GetPersonaPendienteClavePromotor();

            var jsonResult = Json(ListaPersona, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        public JsonResult AsignarClavePromotor(int idUsuario, string cvePromotor)
        {
            if (!DataManagerLideri.ExistsMatricula(cvePromotor))
            {
                int respuesta = DataManagerLideri.AsignarCvePromotor(idUsuario, cvePromotor);

                if (respuesta > 0)
                    return Json("Los datos fueron guardados correctamente, se le notificará por correo al usuario.");
                else
                    return Json("Upps! hubo algún error, favor de intentar mas tarde.");
            }else
                return Json("La clave promotor ya existe, favor ingrese otra");

        }
        #endregion

        #region Index
        // GET: Persona
        [GrupoLideriVerificarRol]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CargarPersonas(string parametro)
        {
            List<FO_Item_Combo> ListaPersonas = DataManagerLideri.GetPersonas();

            ListaPersonas = ListaPersonas.OrderBy(x => x.Text).ToList();

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
        public JsonResult InsertPersona(string aMaterno, string aPaterno, string contrasena, string email, string fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario, string CURP)
        {
            int respuesta = DataManagerLideri.InsertUsuario(aMaterno, aPaterno, contrasena, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, nombre, rfc, telefono, usuario, CURP);


            if (respuesta > 0)
                return Json("Persona agregada correctamente, queda pendiento el VoBo de RH");
            else
                return Json("Upps! hubo algún error, favor de intentar mas tarde.");
        }

        [HttpPost]
        public ActionResult UpdatePersona(string aMaterno, string aPaterno, string contrasena, string email, string fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario, int idUsuario, string CURP, bool checkRH)
        {
            int respuesta = DataManagerLideri.UpdateUsuario(aMaterno, aPaterno, contrasena, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, nombre, rfc, telefono, usuario, idUsuario, CURP, checkRH);

            if (respuesta > 0)
                return Json("Se actualizaron los datos de la persona");
            else
                return Json("Upps! hubo algún error, favor de intentar mas tarde.");

        }

        [HttpPost]
        public ActionResult DeletePersona(int idUsuario)
        {
            int respuesta = DataManagerLideri.DeleteUsuario(idUsuario);

            if (respuesta > 0)
                return Json("Eliminó el registro");
            else
                return Json("Upps! hubo algún error, favor de intentar mas tarde.");
        } 
        #endregion
    }
}