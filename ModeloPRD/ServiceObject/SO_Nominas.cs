using ModeloPRD.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Nominas
    {

        private string SP_NOM_GET_COMISIONES = "SP_NOM_GET_COMISIONES";
        private string SP_NOM_GET_HISTORIAL_COMISION = "SP_NOM_GET_HISTORIAL_COMISION";

        public DataSet GetNominasComision()
        {
            try
            {
                DataSet datos = null;
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                datos = conexion.EjecutarStoredProcedure(SP_NOM_GET_COMISIONES, parametros);

                return datos;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetHistorialNominaPersona(int idPersona)
        {
            try
            {
                DataSet datos = null;
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("idPersona", idPersona);

                datos = conexion.EjecutarStoredProcedure(SP_NOM_GET_HISTORIAL_COMISION, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
