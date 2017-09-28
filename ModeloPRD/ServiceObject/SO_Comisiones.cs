using ModeloPRD.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Comisiones
    {
        public DataSet GetComosionesPromotor(int idPersona, string fechaIncial = "", string fechaFinal = "")
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                
                parametros.Add("fechaInicial", fechaIncial);
                parametros.Add("fechaFinal", fechaFinal);
                parametros.Add("idUsuario", idPersona);

                datos = conexion.EjecutarStoredProcedure("SP_PROD_GET_COMISION_FOLIOS_PROMOTOR", parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetComosionesGerente(int idPersona, string fechaIncial, string fechaFinal)
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("fechaInicial", fechaIncial);
                parametros.Add("fechaFinal", fechaFinal);
                parametros.Add("idUsuario", idPersona);

                datos = conexion.EjecutarStoredProcedure("SP_PROD_GET_COMISION_FOLIOS_GERENTE", parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
