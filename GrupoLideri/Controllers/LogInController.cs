using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingresar([Bind(Include = "Usuario,Contrasena")] DO_Persona persona)
        {
            if (ModelState.IsValid)
            {
                DO_Persona usuario = DataManagerLideri.LogIn(persona.Usuario, persona.Contrasena);

                if (usuario != null)
                {
                    Session["UsuarioConectado"] = usuario;
                    InicializarSession(usuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
            
        }

        private void InicializarSession(DO_Persona usuario)
        {
            Session["PROMOTOR"] = usuario.idJerarquia == 1 ? true : false;
            Session["PROMOTORENTRENADOR"] = usuario.idJerarquia == 2 ? true : false;
            Session["GERENTE"] = usuario.idJerarquia == 3 ? true : false;
            Session["GERENTEPROMOTOR"] = usuario.idJerarquia == 4 ? true : false;
            Session["VICEPRESIDENTE"] = usuario.idJerarquia == 5 ? true : false;
            Session["RECURSOSHUMANOS"] = usuario.idJerarquia == 6 ? true : false;
            Session["NOMINAS"] = usuario.idJerarquia == 7 ? true : false;
            Session["SISTEMAS"] = usuario.idJerarquia == 8 ? true : false;
            Session["DIRECTIVO"] = usuario.idJerarquia == 9 ? true : false;
            Session["ADMINISTRACION"] = usuario.idJerarquia == 10 ? true : false;
        }
    }
}