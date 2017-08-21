﻿using GrupoLideri.Models;
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
    }
}