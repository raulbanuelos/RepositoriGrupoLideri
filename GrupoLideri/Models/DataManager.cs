using System;
using Modelo.ServiceObject;
using Modelo;
using System.Collections.Generic;
using System.Data;

namespace GrupoLideri.Models
{
    public static class DataManager
    {
        #region Usuario
        public static DO_Persona LogIn(string usuario, string contrasena)
        {
            DO_Persona persona = null;

            SO_Persona ServicioPersona = new SO_Persona();

            TBL_USUARIOS informacionBD = ServicioPersona.Login(usuario, contrasena);

            if (informacionBD != null)
            {
                persona = new DO_Persona();
                persona.idPersona = informacionBD.ID_USUARIO;
                persona.Nombre = informacionBD.NOMBRE;
                persona.ApellidoMaterno = informacionBD.APELLIDO_MATERNO;
                persona.ApellidoPaterno = informacionBD.APELLIDO_PATERNO;
                persona.idJerarquia = informacionBD.ID_JERARQUIA;
                
            }
            return persona;
        }
        #endregion

        #region Folio
        public static bool InsertOrUpdateFolioSIAC(N_Folio_SIAC folio)
        {
            SO_Folio ServicioFolio = new SO_Folio();

            TBL_FOLIOS n_folio = new TBL_FOLIOS();
            n_folio.AREA = folio.AREA;
            n_folio.CAMPANA = folio.CAMPANA;
            n_folio.CLAVE_EMPRESA = folio.CLAVE_EMPRESA;
            n_folio.CORREO_ELECTRONICO = folio.CORREO_ELECTRONICO;
            n_folio.DESCRIPCION_VALIDA_ADEUDO = folio.DESCRIPCION_VALIDA_ADEUDO;
            n_folio.DIVICION = folio.DIVICION;
            n_folio.ESTATUS_ATENCION_MULTIORDEN = folio.ESTATUS_ATENCION_MULTIORDEN;
            //n_folio.ESTATUS_PAGADO =
            n_folio.ESTATUS_PISA_MULTIORDEN = folio.ESTATUS_PISA_MULTIORDEN;
            n_folio.ESTATUS_PISA_TV = folio.ESTATUS_PISA_TV;
            n_folio.ESTATUS_SIAC = folio.ESTATUS_SIAC;
            n_folio.ESTRATEGIA = folio.ESTRATEGIA;
            n_folio.ETAPA_PISA_MULTIORDEN = folio.ETAPA_PISA_MULTIORDEN;
            n_folio.ETAPA_PISA_TV = folio.ETAPA_PISA_TV;
            n_folio.ETIQUETA_TRAFICO_VOZ = folio.ETIQUETA_TRAFICO_VOZ;
            //n_folio.FECHA_CALCULO_COMISION
            n_folio.FECHA_CAMBIO_ESTATUS_SIAC = folio.FECHA_CAMBIO_ESTATUS_SIAC;
            n_folio.FECHA_CAPTURA = Convert.ToDateTime(folio.FECHA_CAPTURA);
            // n_folio.FECHA_CREACION = 
            n_folio.FECHA_FACTURCION = folio.FECHA_FACTURCION != null ? folio.FECHA_FACTURCION : string.Empty;
            n_folio.FECHA_NACIMIENTO = folio.FECHA_NACIMIENTO;
            n_folio.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio.FECHA_OS_ALTA_LINEA_MULTIORDEN;
            n_folio.FECHA_OS_TV = folio.FECHA_OS_TV;
            n_folio.FECHA_TRAFICO_DATOS = folio.FECHA_TRAFICO_DATOS;
            n_folio.FECHA_TRAFICO_VOZ = folio.FECHA_TRAFICO_VOZ;
            n_folio.FOLIO_SIAC = folio.FOLIO_SIAC;
            n_folio.ID = folio.ID;
            //n_folio.ID_FOLIO =
            n_folio.LINEA_CONTRATADA = folio.LINEA_CONTRATADA;
            n_folio.MOTIVO_RECHAZO = folio.MOTIVO_RECHAZO;
            n_folio.NOMBRE_EMPRESA = folio.NOMBRE_EMPRESA;
            n_folio.OBSERVACIONES = folio.OBSERVACIONES;
            n_folio.ORDEN_SERVICIO_TV = folio.ORDEN_SERVICIO_TV;
            n_folio.OS_ALTA_LINEA_MULTIORDEN = folio.OS_ALTA_LINEA_MULTIORDEN;
            n_folio.PAQUETE = folio.PAQUETE;
            n_folio.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio.PISA_OS_FECHA_POSTEO_MULTIORDEN;
            n_folio.PISA_OS_FECHA_POSTEO_TV = folio.PISA_OS_FECHA_POSTEO_TV;
            n_folio.PROMOTOR = folio.PROMOTOR;
            n_folio.RESPUESTA_TELMEX = folio.RESPUESTA_TELMEX;
            n_folio.SERVICIO_FACTURACION_TERCEROS = folio.SERVICIO_FACTURACION_TERCEROS;
            n_folio.TELEFONO_ASIGNADO = folio.TELEFONO_ASIGNADO;
            n_folio.TELEFONO_PORTADO = folio.TELEFONO_PORTADO;
            n_folio.TIENDA = folio.TIENDA;
            n_folio.TIPO_LINEA = folio.TIPO_LINEA;
            n_folio.TRAFICO_DATOS = folio.TRAFICO_DATOS;
            n_folio.TRAFICO_VOZ_ENTRANTE = folio.TRAFICO_VOZ_ENTRANTE;
            n_folio.TRAFICO_VOZ_SALIENTE = folio.TRAFICO_VOZ_SALIENTE;
            n_folio.TERMINAL = folio.Terminal;
            n_folio.DISTRITO = folio.Distrito;
            n_folio.TECELULAR = folio.TeCelular;

            bool existe = ServicioFolio.ExistsFolio(n_folio.FOLIO_SIAC);

            if (existe)
            {
                return ServicioFolio.UpdateFolioSIAC(n_folio);
            }
            else
            {
                n_folio.FECHA_CREACION = DateTime.Now;
                return ServicioFolio.InsertFolio(n_folio);
            }
            

        }
        #endregion

        #region Promotor

        /// <summary>
        /// Método que obtiene todos los folios de un promotor.
        /// </summary>
        /// <param name="fechaIncial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public static List<N_Folio_SIAC> GetFoliosPromotor(string fechaIncial, string fechaFinal, int idUsuario,int isPosteada)
        {
            //Inicializamos los servicios de SO_Folio.
            SO_Folio ServicioFolio = new SO_Folio();

            //Declaramos una lista la cual sera la que retornemos en el método.
            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            //Declaramos un dataset en el cual guardaremos la información de la base de datos.
            DataSet informacionBD = new DataSet();

            //Ejecutamos el método para obtener los folios. El resultado lo asignamos al objeto dataset.
            informacionBD = ServicioFolio.GetFoliosPromotor(fechaIncial, fechaFinal, idUsuario,isPosteada);

            //Verificamos si el objeto resultante no es nulo.
            if (informacionBD != null)
            {
                //Verificamos que el dataset contenga al menos una tabla y al menos un registro.
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    //Iteramos los registros de la primer tabla.
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        //Decalaramos un objeto de tipo N_Folio_SIAC el cual agregaremos a la lista.
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        //Mapeamos los valores obtenidos a las propiedades correspondientes del objeto.
                        folio.FECHA_CAPTURA = element["FECHA_CAPTURA"].ToString();
                        folio.FOLIO_SIAC = element["FOLIO_SIAC"].ToString();
                        folio.ESTATUS_SIAC = element["ESTATUS_SIAC"].ToString();
                        folio.TIPO_LINEA = element["TIPO_LINEA"].ToString();
                        folio.LINEA_CONTRATADA = element["LINEA_CONTRATADA"].ToString();
                        folio.PAQUETE = element["PAQUETE"].ToString();
                        folio.OBSERVACIONES = element["OBSERVACIONES"].ToString();
                        folio.ESTATUS_PISA_MULTIORDEN = element["ESTATUS_PISA_MULTIORDEN"].ToString();
                        folio.ESTATUS_PAGADO = Convert.ToBoolean(element["ESTATUS_PAGADO"].ToString());
                        folio.TELEFONO_ASIGNADO = element["TELEFONO_ASIGNADO"].ToString();
                        folio.ORDEN_SERVICIO_TV = element["ORDEN_SERVICIO_TV"].ToString();
                        folio.COMISION_PAQUETE = Convert.ToDouble(element["COMISION_PAQUETE"]);
                        folio.PORCENTAJE_COMISION = Convert.ToDouble(element["PORCENTAJE_COMISION"]);
                        folio.COMISION_TOTAL = Convert.ToDouble(element["COMISION_TOTAL"]);

                        /*Gerente
                         * 
                         * fecha_captura, promotor (nombre), folio siac, estatus siac, tipo de linea, linea contratada, paquete, telefono asignado, estatus multiorden, orden de servicio, comision.
                         * 
                         */

                        /*gerente promotor
                         *
                         * fecha_captura, promotor, estrategia, area, folio siac, estatus siac, tipo de linea, linea contratada, paquete,telefono asignado, estatus multiorden, orden de servicio, comisión.
                         * 
                         */ 

                        //Agregamos el objeto a la lista resultante.
                        listaResultante.Add(folio);
                    }
                }
            }

            //Retornamos la lista.
            return listaResultante;
        }

        #endregion
    }
}