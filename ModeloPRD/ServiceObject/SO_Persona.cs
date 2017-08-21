using ModeloPRD.SQLServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Persona
    {
        public TBL_USUARIO Login(string usuario, string contrasena)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    var persona = (from p in Contexto.TBL_USUARIO
                                   where p.CONTRASENA == contrasena && p.USUARIO == usuario
                                   select p).ToList().FirstOrDefault();

                    return persona;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }

        public IList ExistsMatricula(string matricula)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    var persona = (from p in Contexto.TBL_USUARIO
                                   where p.MATRICULA == matricula
                                   select p).ToList();

                    return persona;
                }
            }
            catch (Exception er)
            {

                throw;
            }
        }
    }
}
