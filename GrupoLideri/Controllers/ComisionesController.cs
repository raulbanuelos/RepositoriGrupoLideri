using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class ComisionesController : Controller
    {
        #region Promotor
        // GET: Comisiones
        public ActionResult Promotor()
        {
            return View();
        }

        public JsonResult GetComicionPromotor(string fechaIncial, string fechaFinal)
        {
            DO_Persona usuarioConectado = (DO_Persona)Session["UsuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            listaResultante = DataManagerLideri.GetComisionPromotor(usuarioConectado.idPersona, fechaIncial, fechaFinal);

            var jsonResult = Json(listaResultante, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        #endregion

        #region Gerente
        public ActionResult Gerente()
        {
            return View();
        } 

        public JsonResult GetComicionGerente(string fechaIncial, string fechaFinal)
        {
            DO_Persona usuarioConectado = (DO_Persona)Session["UsuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            listaResultante = DataManagerLideri.GetComisionGerente(usuarioConectado.idPersona, fechaIncial, fechaFinal);

            var jsonResult = Json(listaResultante, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        #endregion
    }
}