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

            if (nombreControlador.Equals("FolioSIAC"))
            {
                JerarquiasPermitidas.Add(15);
                JerarquiasPermitidas.Add(17);
                JerarquiasPermitidas.Add(2018);

                //mientras---borrar
                JerarquiasPermitidas.Add(1);
                return JerarquiasPermitidas.Contains(idJerarquia);
            }

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