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
        private string SP_NOM_GET_COMISIONES_RESUMEN = "SP_NOM_GET_COMISIONES_RESUMEN";
        private string SP_NOM_SET_FOLIOS_PAGADOS = "SP_NOM_SET_FOLIOS_PAGADOS";

        public DataSet GetNominaComisionResumen()
        {
            try
            {
                DataSet datos = null;
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> paramentros = new Dictionary<string, object>();

                datos = conexion.EjecutarStoredProcedure(SP_NOM_GET_COMISIONES_RESUMEN, paramentros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

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

        public int SetPagoComisiones(string nombreSemana)
        {
            try
            {
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("semana", nombreSemana);

                conexion.EjecutarStoredProcedure(SP_NOM_SET_FOLIOS_PAGADOS, parametros);

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
