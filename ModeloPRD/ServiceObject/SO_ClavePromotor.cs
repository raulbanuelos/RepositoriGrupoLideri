using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_ClavePromotor
    {
        public int Insert(string cvePromotor,int idUsuario)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    TBL_CLAVE_PROMOTOR clave = new TBL_CLAVE_PROMOTOR();

                    clave.CLAVE_PROMOTOR = cvePromotor;
                    clave.FECHA_CREACION = DateTime.Now;
                    clave.ID_USUARIO = idUsuario;

                    Conexion.TBL_CLAVE_PROMOTOR.Add(clave);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }
    }
}
