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
        public IList GetJerarquias()
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var Lista = (from a in Conexion.TBL_JERARQUIA
                                 select a).OrderBy(x => x.JERARQUIA).ToList();

                    return Lista;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }
    }
}
