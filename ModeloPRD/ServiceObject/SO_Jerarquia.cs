using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Jerarquia
    {
        public IList GetJerarquias(int valor)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var Lista = (from a in Conexion.TBL_JERARQUIA
                                 where a.VALOR <= valor
                                 select a).OrderBy(x => x.JERARQUIA).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetValor(int idJerarquia)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    int valor = (from a in Conexion.TBL_JERARQUIA
                                 where a.ID_JERARQUIA == idJerarquia
                                 select a.VALOR).First();

                    return valor;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
