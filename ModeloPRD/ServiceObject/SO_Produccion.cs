using ModeloPRD.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Produccion
    {
        #region Attributes
        private string SP_PROD_GET_PRODUCCION_FOLIOS_PROMOTOR = "SP_PROD_GET_PRODUCCION_FOLIOS_PROMOTOR";
        private string SP_PROD_GET_PRODUCCION_FOLIOS_GERENTE = "SP_PROD_GET_PRODUCCION_FOLIOS_GERENTE";
        private string SP_PROD_GET_PAQUETES_GERENTE = "SP_PROD_GET_PAQUETES_GERENTE";
        private string SP_PROD_GET_POSTEADO_VS_PRODUCCION_GERENTE = "SP_PROD_GET_POSTEADO_VS_PRODUCCION_GERENTE";
        private string SP_PROD_GET_POSTEADO_VS_PRODUCCION_PROMOTOR = "SP_PROD_GET_POSTEADO_VS_PRODUCCION_PROMOTOR";
        #endregion

        public DataSet GetPosteadosVSProduccionPromotor(int idPersona, string fechaInicial, string fechaFinal)
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("", idPersona);
                parametros.Add("", fechaInicial);
                parametros.Add("", fechaFinal);

                datos = conexion.EjecutarStoredProcedure(SP_PROD_GET_POSTEADO_VS_PRODUCCION_PROMOTOR, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetPosteadosVSProducionGerente(int idPersona, string fechaInicial, string fechaFinal)
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idPersona",idPersona);
                parametros.Add("fechaInicial", fechaInicial);
                parametros.Add("fechaFinal", fechaFinal);

                datos = conexion.EjecutarStoredProcedure(SP_PROD_GET_POSTEADO_VS_PRODUCCION_GERENTE, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetProduccionPaquetesGerente(int idPersona)
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idPersona", idPersona);

                datos = conexion.EjecutarStoredProcedure(SP_PROD_GET_PAQUETES_GERENTE, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetProduccionPromotor(int idPersona, string fechaInicial, string fechaFinal)
        {
            try
            {
                DataSet datos = null;
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idPersona);
                parametros.Add("fechaInicial", fechaInicial);
                parametros.Add("fechaFinal",fechaFinal);

                datos = conexion.EjecutarStoredProcedure(SP_PROD_GET_PRODUCCION_FOLIOS_PROMOTOR, parametros);

                return datos;


            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet getProduccionGerente(int idPersona, string fechaInicial, string fechaFinal)
        {
            try
            {
                DataSet datos = null;
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idPersona);
                parametros.Add("fechaInicial", fechaInicial);
                parametros.Add("fechaFinal", fechaFinal);

                datos = conexion.EjecutarStoredProcedure(SP_PROD_GET_PRODUCCION_FOLIOS_GERENTE, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
