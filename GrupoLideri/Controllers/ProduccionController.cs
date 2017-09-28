using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class ProduccionController : Controller
    {
        #region Gerente
        public ActionResult Gerente()
        {
            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            string fechaInicial = "01/01/2017";
            string fechaFinal = "30/08/2017";

            listaResultante = DataManagerLideri.GetProduccionGerente(usuarioConectado.idPersona, fechaInicial, fechaFinal);

            ViewBag.ListaProduccionGerente = listaResultante;

            return View();
        }
        #endregion

        #region Promotor
        public ActionResult Promotor()
        {
            DO_Persona usuarioConectado = (DO_Persona)Session["usuarioConectado"];

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            string fechaInicial = "01/01/2017";
            string fechaFinal = "30/08/2017";

            listaResultante = DataManagerLideri.GetProduccionPromotor(usuarioConectado.idPersona, fechaInicial, fechaFinal);

            ViewBag.ListaProduccionPromotor = listaResultante;

            return View();
        } 
        #endregion
    }
}