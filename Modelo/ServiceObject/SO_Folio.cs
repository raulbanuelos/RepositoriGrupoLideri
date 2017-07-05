using Modelo.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Modelo.ServiceObject
{
    public class SO_Folio
    {
        /// <summary>
        /// Método que inserta un objeto de tipo TBL_Folios en la tabla.
        /// </summary>
        /// <param name="folio">Objeto de tipo TBL_Folios que se quiere insertar.</param>
        /// <returns>Retorna un true si se ejecutó de manera correcta, un false si hubo algun problema.</returns>
        public bool InsertFolio(TBL_FOLIOS folio)
        {
            try
            {
                //Inicializamos la conexión a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Agregamos el objeto a la tabla TBL_FOLIOS.
                    Contexto.TBL_FOLIOS.Add(folio);

                    //Guardamos los cambios y el resultado nos indicará el numero de elementos afectados en la base de datos.
                    int registros = Contexto.SaveChanges();

                    //Retornamos el valor resultante de la comparanción.
                    return registros > 0;
                }
            }
            catch (Exception er)
            {
                // Registrar error en BD  con er.InnerException.ToString();
                return false;
            }

        }

        /// <summary>
        /// Método que actualiza un registro de folio SIAC.
        /// </summary>
        /// <param name="folio"></param>
        /// <returns></returns>
        public bool UpdateFolioSIAC(TBL_FOLIOS folio)
        {
            try
            {
                //Inicializamos la conexión a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Obtenemos el registro del folio.
                    TBL_FOLIOS obj = Contexto.TBL_FOLIOS.Where(x => x.FOLIO_SIAC == folio.FOLIO_SIAC).FirstOrDefault();

                    //Mapeamos los valores a las propiedades correspondientes.
                    obj.AREA = folio.AREA;
                    obj.CAMPANA = folio.CAMPANA;
                    obj.CLAVE_EMPRESA = folio.CLAVE_EMPRESA;
                    obj.CORREO_ELECTRONICO = folio.CORREO_ELECTRONICO;
                    obj.DESCRIPCION_VALIDA_ADEUDO = folio.DESCRIPCION_VALIDA_ADEUDO;
                    obj.DISTRITO = folio.DISTRITO;
                    obj.DIVICION = folio.DIVICION;
                    obj.ESTATUS_ATENCION_MULTIORDEN = folio.ESTATUS_ATENCION_MULTIORDEN;
                    obj.ESTATUS_PAGADO = folio.ESTATUS_PAGADO;
                    obj.ESTATUS_PISA_MULTIORDEN = folio.ESTATUS_PISA_MULTIORDEN;
                    obj.ESTATUS_PISA_TV = folio.ESTATUS_PISA_TV;
                    obj.ESTATUS_SIAC = folio.ESTATUS_SIAC;
                    obj.ESTRATEGIA = folio.ESTRATEGIA;
                    obj.ETAPA_PISA_MULTIORDEN = folio.ETAPA_PISA_MULTIORDEN;
                    obj.ETAPA_PISA_TV = folio.ETAPA_PISA_TV;
                    obj.ETIQUETA_TRAFICO_VOZ = folio.ETIQUETA_TRAFICO_VOZ;
                    obj.FECHA_CALCULO_COMISION = folio.FECHA_CALCULO_COMISION;
                    obj.FECHA_CAMBIO_ESTATUS_SIAC = folio.FECHA_CAMBIO_ESTATUS_SIAC;
                    obj.FECHA_CAPTURA = folio.FECHA_CAPTURA;
                    obj.FECHA_FACTURCION = folio.FECHA_FACTURCION;
                    obj.FECHA_NACIMIENTO = folio.FECHA_NACIMIENTO;
                    obj.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio.FECHA_OS_ALTA_LINEA_MULTIORDEN;
                    obj.FECHA_OS_TV = folio.FECHA_OS_TV;
                    obj.FECHA_TRAFICO_DATOS = folio.FECHA_TRAFICO_DATOS;
                    obj.FECHA_TRAFICO_VOZ = folio.FECHA_TRAFICO_VOZ;
                    obj.ID = folio.ID;
                    obj.LINEA_CONTRATADA = folio.LINEA_CONTRATADA;
                    obj.MOTIVO_RECHAZO = folio.MOTIVO_RECHAZO;
                    obj.NOMBRE_EMPRESA = folio.NOMBRE_EMPRESA;
                    obj.OBSERVACIONES = folio.OBSERVACIONES;
                    obj.ORDEN_SERVICIO_TV = folio.ORDEN_SERVICIO_TV;
                    obj.OS_ALTA_LINEA_MULTIORDEN = folio.OS_ALTA_LINEA_MULTIORDEN;
                    obj.PAQUETE = folio.PAQUETE;
                    obj.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio.PISA_OS_FECHA_POSTEO_MULTIORDEN;
                    obj.PISA_OS_FECHA_POSTEO_TV = folio.PISA_OS_FECHA_POSTEO_TV;
                    obj.PROMOTOR = folio.PROMOTOR;
                    obj.RESPUESTA_TELMEX = folio.RESPUESTA_TELMEX;
                    obj.SERVICIO_FACTURACION_TERCEROS = folio.SERVICIO_FACTURACION_TERCEROS;
                    obj.TECELULAR = folio.TECELULAR;
                    obj.TELEFONO_ASIGNADO = folio.TELEFONO_ASIGNADO;
                    obj.TELEFONO_PORTADO = folio.TELEFONO_PORTADO;
                    obj.TERMINAL = folio.TERMINAL;
                    obj.TIENDA = folio.TIENDA;
                    obj.TIPO_LINEA = folio.TIPO_LINEA;
                    obj.TRAFICO_DATOS = folio.TRAFICO_DATOS;
                    obj.TRAFICO_VOZ_ENTRANTE = folio.TRAFICO_VOZ_ENTRANTE;
                    obj.TRAFICO_VOZ_SALIENTE = folio.TRAFICO_VOZ_SALIENTE;

                    //Cambiamos el estado de registro a modificado.
                    Contexto.Entry(obj).State = EntityState.Modified;

                    //Ejecutamos el método para guardar los nuevos valores, el resultado nos indica el número de registros afectados.
                    int r = Contexto.SaveChanges();

                    //Retornamos un true si el número de registros es mayor a cero, sino retornamos un false.
                    return r > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                //Si ocurre algún error retornamos una false.
                return false;
            }
        }

        /// <summary>
        /// Método para saber si un folio existe.
        /// </summary>
        /// <param name="folioSICAC"></param>
        /// <returns></returns>
        public bool ExistsFolio(string folioSICAC)
        {
            try
            {
                //Inicializamos la conexión a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Realizamos la consulta buscando el número de folio, obteniendo el número de registros encontrados, el cual lo asignamos a una variable local.
                    int r = Contexto.TBL_FOLIOS.Where(x => x.FOLIO_SIAC == folioSICAC).ToList().Count;

                    //Retornamos un true si el número de registros es mayor a cero, sino retornamos un false.
                    return r > 0 ? true : false;
                }
            }
            catch (Exception er)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que obtiene todos los folios de un promotor a partir de la fecha incial y fecha final.
        /// </summary>
        /// <param name="fechaIncial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataSet GetFoliosPromotor(string fechaIncial, string fechaFinal, int idUsuario,int isPosteada)
        {
            try
            {
                //Declaramos un objeto de tipo DataSet que será el que guarde los resultados de la consulta.
                DataSet datos = null;

                //Declaramos un objeto con el cual nos permitira conectarnos hacia la base de datos.
                GrupoLideri_SQL conexion = new GrupoLideri_SQL();

                //Declaramos un diccionario en el cual guardaremos los parámetros que requiere el procedimiento.
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                //Agregamos los parámertros necesarios del procedimiento.
                parametros.Add("fechaInicial", fechaIncial);
                parametros.Add("fechaFinal", fechaFinal);
                parametros.Add("idUsuario", idUsuario);
                parametros.Add("isPosteada", isPosteada);

                //LLamamos al método para ejecutar el procedimiento, el resultado lo guardamos 
                datos = conexion.EjecutarStoredProcedure("SP_PROMOTOR_GET_FOLIOS", parametros);

                //Retornamos el resultado.
                return datos;
            }
            catch (Exception)
            {
                //Si ocurre algún error, retornamos un nulo.
                return null;
            }

        }
    }
}
