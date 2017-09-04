using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class PersonaController : Controller
    {
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
            DO_Persona usuarioConectado = (DO_Persona)Session["UsuarioConectado"];

            int valorJerarquia = DataManagerLideri.GetValorJerarquia(usuarioConectado.idJerarquia);
            
            List<FO_Item_Combo> ListaJerarquias = DataManagerLideri.GetJearaquias(valorJerarquia);

            List<SelectListItem> Jerarquias = DataManagerLideri.ToDropdownListFromItemCombo(ListaJerarquias);

            return Json(new SelectList(Jerarquias, "Value", "Text"));
        }

        [HttpPost]
        public JsonResult InsertPersona()
        {
            int archivosGuardados = 0;
            string aMaterno = Request.Form["_aMaterno"];
            string aPaterno = Request.Form["_aPaterno"];
            string email = Request.Form["_eMail"]; ;
            string fechaNacimiento = Request.Form["_fechaNacimiento"]; ;
            int idJefe = Convert.ToInt32(Request.Form["_idJefe"]);
            int idJerarquia = Convert.ToInt32(Request.Form["_idJerarquia"]); 
            string nombre = Request.Form["_nombre"];
            string rfc = Request.Form["_rfc"];
            string telefono = Request.Form["_telefono"];
            string CURP = Request.Form["_curp"];

            int idUsuarioAgregado = DataManagerLideri.InsertUsuario(aMaterno, aPaterno, email, Convert.ToDateTime(fechaNacimiento), idJefe, idJerarquia, nombre, rfc, telefono, CURP);
            
            if (idUsuarioAgregado > 0)
            {
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];

                            MemoryStream target = new MemoryStream();
                            file.InputStream.CopyTo(target);
                            byte[] data = target.ToArray();

                            DataManagerLideri.InsertArchivoUsuario(data, idUsuarioAgregado);
                            archivosGuardados += 1;
                        }

                        return Json("Persona agregada correctamente, queda pendiente el VoBo de RH");
                    }
                    catch (Exception)
                    {
                        return Json("Error al guardar los archivos");
                    }
                }
                return Json("La persona se agrego, pero no agregaste ninguna documentación");
            }
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

        //public ActionResult UploadFiles()
        //{
        //    StringBuilder s = new StringBuilder();
        //    foreach (string key in Request.Form.Keys)
        //    {
        //        s.AppendLine(key + ": " + Request.Form[key]);
        //    }
        //    string formData = s.ToString();

        //    if (Request.Files.Count > 0)
        //    {

        //        try
        //        {
        //            HttpFileCollectionBase files = Request.Files;

        //            for (int i = 0; i < files.Count; i++)
        //            {
        //                HttpPostedFileBase file = files[i];

        //                MemoryStream target = new MemoryStream();
        //                file.InputStream.CopyTo(target);
        //                byte[] data = target.ToArray();

        //                DataManagerLideri.InsertArchivoUsuario(data, 1);

        //            }

        //            return Json("Seleccionaste " + Request.Files.Count + " documentos");
        //        }
        //        catch (Exception)
        //        {
        //            return Json("Error al adjuntar los documentos");
        //        }

                
        //    }
        //    else
        //    {
        //        return Json("No seleccionó ningun documento");
        //    }
        //}
        #endregion
    }
}