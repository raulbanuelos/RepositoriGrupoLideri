using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class GrupoLideriVerificarRol : AuthorizeAttribute
    {
        /*
         * 1:       VICEPRESIDENTE
         * 10:      GERENTE
         * 14:      PROMOTOR
         * 15:      ADMINISTRATIVO
         * 16:      VALIDADOR
         * 17:      SISTEMAS
         * 1018:    RECURSOS HUMANOS
         * 1019:    NOMINAS
         * 2018:    DIRECTIVO
         * 2017:    GERENTE PROMOTOR
         */
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContext contexto = HttpContext.Current;

            DO_Persona usuario = (DO_Persona)contexto.Session["UsuarioConectado"];

            if (usuario == null)
            {
                return false;
            }

            int idJerarquia = usuario.idJerarquia;

            string nombreAccion = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");

            string nombreControlador = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");

            List<int> JerarquiasPermitidas = new List<int>();

            #region Subir PIPES
            if (nombreControlador.Equals("FolioSIAC"))
            {
                JerarquiasPermitidas.Add(15);
                JerarquiasPermitidas.Add(17);
                JerarquiasPermitidas.Add(2018);
                JerarquiasPermitidas.Add(2019);

                //Borrar
                JerarquiasPermitidas.Add(1);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Mi organigrama
            if (nombreControlador.Equals("MiOrganigrama"))
            {
                JerarquiasPermitidas.Add(10);
                JerarquiasPermitidas.Add(2017);
                JerarquiasPermitidas.Add(1);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Mi organización
            if (nombreControlador.Equals("MiOrganizacion"))
            {
                JerarquiasPermitidas.Add(2017);
                JerarquiasPermitidas.Add(1);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Mis comisiones
            if (nombreControlador.Equals("MisComisiones"))
            {
                JerarquiasPermitidas.Add(1);
                JerarquiasPermitidas.Add(10);
                JerarquiasPermitidas.Add(14);
                JerarquiasPermitidas.Add(2017);
                JerarquiasPermitidas.Add(2018);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Mis folios
            if (nombreControlador.Equals("MisFolios"))
            {
                JerarquiasPermitidas.Add(1);
                JerarquiasPermitidas.Add(10);
                JerarquiasPermitidas.Add(14);
                JerarquiasPermitidas.Add(2017);
                JerarquiasPermitidas.Add(2018);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Over
            if (nombreControlador.Equals("Over"))
            {
                JerarquiasPermitidas.Add(1);
                JerarquiasPermitidas.Add(10);
                JerarquiasPermitidas.Add(2017);
                JerarquiasPermitidas.Add(2018);

                return JerarquiasPermitidas.Contains(idJerarquia);
            }
            #endregion

            #region Home
            if (nombreControlador.Equals("Home"))
            {
                JerarquiasPermitidas.Add(1);
                JerarquiasPermitidas.Add(10);
                JerarquiasPermitidas.Add(14);
                JerarquiasPermitidas.Add(15);
                JerarquiasPermitidas.Add(17);
                JerarquiasPermitidas.Add(1018);
                JerarquiasPermitidas.Add(1019);
                JerarquiasPermitidas.Add(2018);
                JerarquiasPermitidas.Add(2017);
                return JerarquiasPermitidas.Contains(idJerarquia);
            } 
            #endregion

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //En caso de que no esté autorizado, redirigir al siguiente view
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/LogIn/Index.cshtml"
            };
        }
        
    }
}