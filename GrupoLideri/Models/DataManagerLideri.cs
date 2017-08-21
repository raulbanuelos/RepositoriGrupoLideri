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