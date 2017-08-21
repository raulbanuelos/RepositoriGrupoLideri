using ModeloPRD;
using ModeloPRD.ServiceObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoLideri.Models
{
    public static class DataManagerLideri
    {

        #region Usuario
        public static DO_Persona LogIn(string usuario, string contrasena)
        {
            DO_Persona persona = null;

            SO_Persona ServicioPersona = new SO_Persona();

            TBL_USUARIO informacionBD = ServicioPersona.Login(usuario, contrasena);

            if (informacionBD != null)
            {
                persona = new DO_Persona();

                persona.idPersona = informacionBD.ID_USUARIO;
                persona.Nombre = informacionBD.NOMBRE;
                persona.ApellidoPaterno = informacionBD.APELLIDO_PATERNO;
                persona.ApellidoMaterno = informacionBD.APELLIDO_MATERNO;
                persona.idJerarquia = informacionBD.ID_JERARQUIA;
            }

            return persona;
        }
        
        public static DO_Persona GetUsuario(int idUsuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            IList informacionBD = ServicioPersona.GetUsuario(idUsuario);

            DO_Persona persona = null;

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    persona = new DO_Persona();

                    persona.idPersona = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("APELLIDO_MATERNO").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APELLIDO_PATERNO").GetValue(item, null);
                    persona.Contrasena = (string)tipo.GetProperty("CONTRASENA").GetValue(item, null);
                    persona.idJerarquia = (int)tipo.GetProperty("ID_JERARQUIA").GetValue(item, null);
                    persona.idPersona = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.Matricula = (string)tipo.GetProperty("MATRICULA").GetValue(item, null);
                    persona.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    persona.Telefono = (string)tipo.GetProperty("TELEFONO").GetValue(item, null);
                    persona.fechaNacimiento = (DateTime)tipo.GetProperty("FECHA_NACIMIENTO").GetValue(item,null);
                    persona.Email = (string)tipo.GetProperty("EMAIL").GetValue(item, null);
                    
                }
            }

            return persona;
        }

        public static int InsertUsuario(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string matricula, string nombre, string rfc, string telefono, string usuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Insert(materno, paterno, contrasena, email, fechaNacimiento, idJefe, idJerarquia, matricula, nombre, rfc, telefono, usuario);
        }

        public static int UpdateUsuario(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string matricula, string nombre, string rfc, string telefono, string usuario,int idUsuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Update(materno, paterno, contrasena, email, fechaNacimiento, idJefe, idJerarquia, matricula, nombre, rfc, telefono, usuario, idUsuario);
        }

        public static int DeleteUsuario(int idUsuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Delete(idUsuario);
        }

        public static bool ExistsMatricula(string matricula)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            IList informacionBD = ServicioPersona.ExistsMatricula(matricula);

            if (informacionBD != null)
            {
                if (informacionBD.Count > 0)
                    return true;
                else
                    return false;

            }
            else
                return false;
        }
        #endregion
    }
}