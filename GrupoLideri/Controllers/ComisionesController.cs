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
            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            string fechaInicial = "01/01/2017";
            string fechaFinal = "30/08/2017";

            listaResultante = DataManagerLideri.GetComisionPromotor(usuarioConectado.idPersona, fechaInicial, fechaFinal);

            ViewBag.ListaFoliosPromotorPosteados = listaResultante;

            return View();
        }
        #endregion

        #region Gerente
        public ActionResult Gerente()
        {
            DO_Persona usuarioConectado = (DO_Persona)Session["UsuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            string fechaInicial = "01/01/2017";
            string fechaFinal = "30/08/2017";

            listaResultante = DataManagerLideri.GetComisionGerente(usuarioConectado.idPersona, fechaInicial, fechaFinal);

            ViewBag.ListaFoliosPosteados = listaResultante;

            return View();
        } 
        
        #endregion
    }
}