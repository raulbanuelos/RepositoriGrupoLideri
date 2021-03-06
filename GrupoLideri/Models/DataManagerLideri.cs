﻿using ModeloPRD;
using ModeloPRD.ServiceObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Models
{
    public static class DataManagerLideri
    {

        #region Usuario
        public static DO_Persona LogIn(string usuario, string contrasena)
        {
            DO_Persona persona = null;

            SO_Persona ServicioPersona = new SO_Persona();

            TBL_USUARIO informacionBD = ServicioPersona.Login(usuario, contrasena);

            if (informacionBD != null)
            {
                persona = new DO_Persona();

                persona.idPersona = informacionBD.ID_USUARIO;
                persona.Nombre = informacionBD.NOMBRE;
                persona.ApellidoPaterno = informacionBD.APELLIDO_PATERNO;
                persona.ApellidoMaterno = informacionBD.APELLIDO_MATERNO;
                persona.idJerarquia = informacionBD.ID_JERARQUIA;
                
            }

            return persona;
        }

        internal static List<FO_Item_Paquete> GetPaquetesGerente(int idPersona)
        {
            SO_Produccion servicioProduccion = new SO_Produccion();

            List<FO_Item_Paquete> lista = new List<FO_Item_Paquete>();

            DataSet datos = servicioProduccion.GetProduccionPaquetesGerente(idPersona);

            if (datos != null)
            {
                if (datos.Tables.Count > 0 && datos.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in datos.Tables[0].Rows)
                    {
                        FO_Item_Paquete g = new FO_Item_Paquete();

                        g.label = item["PAQUETE"].ToString();
                        g.value = Convert.ToDouble(item["PORCENTAJE"]);

                        lista.Add(g);
                    }
                }
            }

            return lista;
        }

        public static int AsignarCvePromotor(int idUsuario, string cvePromotor)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.AsignarCvePromotor(idUsuario, cvePromotor);
        }

        public static List<FO_Item_Combo> GetPersonas()
        {
            SO_Persona ServicioPersona = new SO_Persona();

            List<FO_Item_Combo> ListaResultante = new List<FO_Item_Combo>();

            IList informacionBD = ServicioPersona.GetUsuarios();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    FO_Item_Combo persona = new FO_Item_Combo();

                    string nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    string apaterno = (string)tipo.GetProperty("APELLIDO_PATERNO").GetValue(item, null);
                    string amaterno = (string)tipo.GetProperty("APELLIDO_MATERNO").GetValue(item, null);

                    persona.Text = nombre + " " + apaterno + " " + amaterno;
                    persona.Value = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);

                    ListaResultante.Add(persona);
                }
            }

            return ListaResultante;
        }
        
        public static DO_Persona GetUsuario(int idUsuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            IList informacionBD = ServicioPersona.GetUsuario(idUsuario);

            DO_Persona persona = null;

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    persona = new DO_Persona();

                    persona.idPersona = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("APELLIDO_MATERNO").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APELLIDO_PATERNO").GetValue(item, null);
                    persona.Contrasena = (string)tipo.GetProperty("CONTRASENA").GetValue(item, null);
                    persona.idJerarquia = (int)tipo.GetProperty("ID_JERARQUIA").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    persona.Telefono = (string)tipo.GetProperty("TELEFONO").GetValue(item, null);
                    persona.fechaNacimiento = (DateTime)tipo.GetProperty("FECHA_NACIMIENTO").GetValue(item,null);
                    persona.Email = (string)tipo.GetProperty("EMAIL").GetValue(item, null);
                    
                }
            }

            return persona;
        }

        public static int InsertUsuario(string materno, string paterno, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono,string CURP)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Insert(materno, paterno, email, fechaNacimiento, idJefe, idJerarquia, nombre, rfc, telefono,CURP);
        }

        public static int UpdateUsuario(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario,int idUsuario,string CURP, bool checkRH)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Update(materno, paterno, contrasena, email, fechaNacimiento, idJefe, idJerarquia, nombre, rfc, telefono, usuario, idUsuario,CURP,checkRH);
        }

        public static int DeleteUsuario(int idUsuario)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Delete(idUsuario);
        }

        public static bool ExistsMatricula(string matricula)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            IList informacionBD = ServicioPersona.ExistsMatricula(matricula);

            if (informacionBD != null)
            {
                if (informacionBD.Count > 0)
                    return true;
                else
                    return false;

            }
            else
                return false;
        }

        public static int InsertClavePromotor(string cvePromotor, int idUsuario)
        {
            SO_ClavePromotor ServicioPromotor = new SO_ClavePromotor();

            return ServicioPromotor.Insert(cvePromotor, idUsuario);
        }

        public static List<DO_Persona> GetPersonaPendienteClavePromotor()
        {
            SO_Persona ServicioPersona = new SO_Persona();
            SO_ArchivoUsuario ServicioArvhivo = new SO_ArchivoUsuario();

            List<DO_Persona> ListaPersona = new List<DO_Persona>();

            IList informacionBD = ServicioPersona.GetUsuariosPendienteClavePromotor();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_Persona persona = new DO_Persona();
                    persona.ArchivosPersonales = new List<DO_Archivo>();

                    persona.idPersona = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("APELLIDO_MATERNO").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APELLIDO_PATERNO").GetValue(item, null);
                    persona.Contrasena = (string)tipo.GetProperty("CONTRASENA").GetValue(item, null);
                    persona.idJerarquia = (int)tipo.GetProperty("ID_JERARQUIA").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    persona.CURP = (string)tipo.GetProperty("CURP").GetValue(item, null);
                    persona.Telefono = (string)tipo.GetProperty("TELEFONO").GetValue(item, null);
                    persona.fechaNacimiento = (DateTime)tipo.GetProperty("FECHA_NACIMIENTO").GetValue(item, null);
                    persona.Email = (string)tipo.GetProperty("EMAIL").GetValue(item, null);

                    IList informacionArchivosBD = ServicioArvhivo.GetArchivosUsuario(persona.idPersona);

                    if (informacionArchivosBD != null)
                    {
                        foreach (var archivo in informacionArchivosBD)
                        {
                            Type tipoArchivo = archivo.GetType();
                            DO_Archivo archivoFisico = new DO_Archivo();

                            archivoFisico.idArchivo = (int)tipoArchivo.GetProperty("ID_ARCHIVO_USUARIO").GetValue(archivo, null);
                            archivoFisico.ArchivoFisico = (byte[])tipoArchivo.GetProperty("ARCHIVO").GetValue(archivo, null);
                            archivoFisico.FechaCreacion = (DateTime)tipoArchivo.GetProperty("FECHA_CREACION").GetValue(archivo, null);
                            archivoFisico.NombreArchivo = "Archivo.pdf";
                            persona.ArchivosPersonales.Add(archivoFisico);

                        }
                    }

                    ListaPersona.Add(persona);
                }
            }

            return ListaPersona;

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
                if (!GetFolioSIAC(n_folio.FOLIO_SIAC).Equals(n_folio))
                {
                    return ServicioFolio.UpdateFolioSIAC(n_folio);
                    
                }

                return true;
            }
            else
            {
                n_folio.FECHA_CREACION = DateTime.Now;
                return ServicioFolio.InsertFolio(n_folio);
            }


        }

        public static N_Folio_SIAC GetFolioSIAC(string folioSIAC)
        {
            SO_Folio ServicioFolios = new SO_Folio();

            TBL_FOLIOS folioBD = ServicioFolios.GetFolio(folioSIAC);

            if (folioBD != null)
            {
                N_Folio_SIAC folio = new N_Folio_SIAC();

                folio.AREA = folioBD.AREA;
                folio.CAMPANA = folioBD.CAMPANA;
                folio.CLAVE_EMPRESA = folioBD.CLAVE_EMPRESA;
                folio.CORREO_ELECTRONICO = folioBD.CORREO_ELECTRONICO;
                folio.DESCRIPCION_VALIDA_ADEUDO = folioBD.DESCRIPCION_VALIDA_ADEUDO;
                folio.Distrito = folioBD.DISTRITO;
                folio.DIVICION = folioBD.DIVICION;
                folio.ESTATUS_ATENCION_MULTIORDEN = folioBD.ESTATUS_ATENCION_MULTIORDEN;
                folio.ESTATUS_PISA_MULTIORDEN = folioBD.ESTATUS_PISA_MULTIORDEN;
                folio.ESTATUS_PISA_TV = folioBD.ESTATUS_PISA_TV;
                folio.ESTATUS_SIAC = folioBD.ESTATUS_SIAC;
                folio.ESTRATEGIA = folioBD.ESTRATEGIA;
                folio.ETAPA_PISA_MULTIORDEN = folioBD.ETAPA_PISA_MULTIORDEN;
                folio.ETAPA_PISA_TV = folioBD.ETAPA_PISA_TV;
                folio.ETIQUETA_TRAFICO_VOZ = folioBD.ETIQUETA_TRAFICO_VOZ;
                folio.FECHA_CAMBIO_ESTATUS_SIAC = folioBD.FECHA_CAMBIO_ESTATUS_SIAC;
                folio.FECHA_CAPTURA = folioBD.FECHA_CAPTURA.ToString();
                folio.FECHA_FACTURCION = folioBD.FECHA_FACTURCION;
                folio.FECHA_NACIMIENTO = folioBD.FECHA_NACIMIENTO;
                folio.FECHA_OS_ALTA_LINEA_MULTIORDEN = folioBD.FECHA_OS_ALTA_LINEA_MULTIORDEN;
                folio.FECHA_OS_TV = folioBD.FECHA_OS_TV;
                folio.FECHA_TRAFICO_DATOS = folioBD.FECHA_TRAFICO_DATOS;
                folio.FECHA_TRAFICO_VOZ = folioBD.FECHA_TRAFICO_VOZ;
                folio.FOLIO_SIAC = folioBD.FOLIO_SIAC;
                folio.ID = folioBD.ID;
                folio.LINEA_CONTRATADA = folioBD.LINEA_CONTRATADA;
                folio.MOTIVO_RECHAZO = folioBD.MOTIVO_RECHAZO;
                folio.NOMBRE_EMPRESA = folioBD.NOMBRE_EMPRESA;
                folio.OBSERVACIONES = folioBD.OBSERVACIONES;
                folio.ORDEN_SERVICIO_TV = folioBD.ORDEN_SERVICIO_TV;
                folio.OS_ALTA_LINEA_MULTIORDEN = folioBD.OS_ALTA_LINEA_MULTIORDEN;
                folio.PAQUETE = folioBD.PAQUETE;
                folio.PISA_OS_FECHA_POSTEO_MULTIORDEN = folioBD.PISA_OS_FECHA_POSTEO_MULTIORDEN;
                folio.PISA_OS_FECHA_POSTEO_TV = folioBD.PISA_OS_FECHA_POSTEO_TV;
                folio.PROMOTOR = folioBD.PROMOTOR;
                folio.RESPUESTA_TELMEX = folioBD.RESPUESTA_TELMEX;
                folio.SERVICIO_FACTURACION_TERCEROS = folioBD.SERVICIO_FACTURACION_TERCEROS;
                folio.TeCelular = folioBD.TECELULAR;
                folio.TELEFONO_ASIGNADO = folioBD.TELEFONO_ASIGNADO;
                folio.TELEFONO_PORTADO = folioBD.TELEFONO_PORTADO;
                folio.Terminal = folioBD.TERMINAL;
                folio.TIENDA = folioBD.TIENDA;
                folio.TIPO_LINEA = folioBD.TIPO_LINEA;
                folio.TRAFICO_DATOS = folioBD.TRAFICO_DATOS;
                folio.TRAFICO_VOZ_ENTRANTE = folioBD.TRAFICO_VOZ_ENTRANTE;
                folio.TRAFICO_VOZ_SALIENTE = folioBD.TRAFICO_VOZ_SALIENTE;
                
                return folio;
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region Jerarquias
        public static List<FO_Item_Combo> GetJearaquias(int valor)
        {
            SO_Jerarquia ServicioJerarquia = new SO_Jerarquia();

            List<FO_Item_Combo> ListaResultante = new List<FO_Item_Combo>();

            IList informacionBD = ServicioJerarquia.GetJerarquias(valor);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    FO_Item_Combo jerarquia = new FO_Item_Combo();

                    jerarquia.Value = (int)tipo.GetProperty("ID_JERARQUIA").GetValue(item, null);
                    jerarquia.Text = (string)tipo.GetProperty("JERARQUIA").GetValue(item, null);

                    ListaResultante.Add(jerarquia);

                }
            }

            return ListaResultante;
        }

        public static int GetValorJerarquia(int idJerarquia)
        {
            SO_Jerarquia ServicioJerarquia = new SO_Jerarquia();

            return ServicioJerarquia.GetValor(idJerarquia);
        }
        #endregion
        
        #region Comisiones
        public static List<N_Folio_SIAC> GetComisionGerente(int idUsuario)
        {
            SO_Comisiones ServiceComisiones = new SO_Comisiones();

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            DataSet informacionBD = new DataSet();

            informacionBD = ServiceComisiones.GetComosionesGerente(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        folio.FECHA_CAPTURA = element["FECHA_CAPTURA"].ToString();
                        folio.NombrePromotor = element["NOMBRE_PROMOTOR"].ToString();
                        folio.FOLIO_SIAC = element["FOLIO_SIAC"].ToString();
                        folio.ESTATUS_SIAC = element["ESTATUS_SIAC"].ToString();
                        folio.TIPO_LINEA = element["TIPO_LINEA"].ToString();
                        folio.LINEA_CONTRATADA = element["LINEA_CONTRATADA"].ToString();
                        folio.PAQUETE = element["PAQUETE"].ToString();
                        folio.TELEFONO_ASIGNADO = element["TELEFONO_ASIGNADO"].ToString();
                        folio.ESTATUS_PISA_MULTIORDEN = element["ESTATUS_PISA_MULTIORDEN"].ToString();
                        folio.ORDEN_SERVICIO_TV = element["ORDEN_SERVICIO_TV"].ToString();
                        folio.COMISION_TOTAL = Convert.ToDouble(element["COMISION_TOTAL"]);
                        /*Gerente
                        * 
                        * fecha_captura, promotor (nombre), folio siac, estatus siac, tipo de linea, linea contratada, paquete, telefono asignado, estatus multiorden, orden de servicio, comision.
                        * 
                        */
                        listaResultante.Add(folio);
                    }
                }
            }

            return listaResultante;
        }

        public static int GetFoliosVendidosGerente(int idPersona)
        {
            int cantidad = 0;

            SO_Comisiones ServiceComisiones = new SO_Comisiones();

            DataSet informacionBD = new DataSet();

            informacionBD = ServiceComisiones.GetComosionesGerente(idPersona);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        cantidad += 1;

                    }
                }
            }

            return cantidad;
        }

        public static double GetComisionGerenteTotal(int idPersona)
        {
            SO_Comisiones ServiceComisiones = new SO_Comisiones();
            
            DataSet informacionBD = new DataSet();

            informacionBD = ServiceComisiones.GetComosionesGerente(idPersona);

            double comisionTotal = 0;

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        
                        folio.COMISION_TOTAL = Convert.ToDouble(element["COMISION_TOTAL"]);
                        comisionTotal += Convert.ToDouble(folio.COMISION_TOTAL);
                        
                    }
                }
            }

            return comisionTotal;
        }
        
        public static List<N_Folio_SIAC> GetComisionPromotor(int idUsuario, string fechaInicial, string fechaFinal)
        {
            SO_Comisiones ServiceComisiones = new SO_Comisiones();

            List<N_Folio_SIAC> listaResultante = new List<N_Folio_SIAC>();

            DataSet informacionBD = new DataSet();

            informacionBD = ServiceComisiones.GetComosionesPromotor(idUsuario, fechaInicial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        folio.FECHA_CAPTURA = element["FECHA_CAPTURA"].ToString();
                        folio.PROMOTOR = element["PROMOTOR"].ToString();
                        folio.ESTRATEGIA = element["ESTRATEGIA"].ToString();
                        folio.AREA = element["AREA"].ToString();
                        folio.FOLIO_SIAC = element["FOLIO_SIAC"].ToString();
                        folio.ESTATUS_SIAC = element["ESTATUS_SIAC"].ToString();
                        folio.TIPO_LINEA = element["TIPO_LINEA"].ToString();
                        folio.LINEA_CONTRATADA = element["LINEA_CONTRATADA"].ToString();
                        folio.PAQUETE = element["PAQUETE"].ToString();
                        folio.TELEFONO_ASIGNADO = element["TELEFONO_ASIGNADO"].ToString();
                        folio.ESTATUS_PISA_MULTIORDEN = element["ESTATUS_PISA_MULTIORDEN"].ToString();
                        folio.ORDEN_SERVICIO_TV = element["ORDEN_SERVICIO_TV"].ToString();
                        folio.COMISION_TOTAL = Convert.ToDouble(element["COMISION_TOTAL"]);
                        
                        /*gerente promotor
                         *
                         * fecha_captura, promotor, estrategia, area, folio siac, estatus siac, tipo de linea, linea contratada, paquete,telefono asignado, estatus multiorden, orden de servicio, comisión.
                         * 
                         */

                        listaResultante.Add(folio);
                    }
                }
            }

            return listaResultante;
        }
        #endregion

        #region ArchivosUsuarios
        public static int InsertArchivoUsuario(byte[] archivo, int idUsuario)
        {
            SO_ArchivoUsuario ServiceArhivoUsuario = new SO_ArchivoUsuario();

            return ServiceArhivoUsuario.Insert(archivo, idUsuario);
        }

        public static void DescargarArchivo(int idArchivo)
        {
            SO_ArchivoUsuario ServicioArchivo = new SO_ArchivoUsuario();

            byte[] archivo = ServicioArchivo.GetArchivo(idArchivo);

            string tipoContenido = MimeMapping.GetMimeMapping("BADE880101HASXZD05.pdf");
            HttpContext.Current.Response.ContentType = tipoContenido;
            HttpContext.Current.Response.AppendHeader("Content-Type", tipoContenido);
            HttpContext.Current.Response.AppendHeader("Content-Length", archivo.Length.ToString());
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "BADE880101HASXZD05.pdf");
            HttpContext.Current.Response.BinaryWrite(archivo);
        }
        #endregion

        #region Genericos
        public static List<SelectListItem> ToDropdownListFromItemCombo(List<FO_Item_Combo> lista)
        {
            List<SelectListItem> DropDownList = new List<SelectListItem>();

            foreach (FO_Item_Combo elemento in lista)
            {
                DropDownList.Add(new SelectListItem { Text = elemento.Text, Value = elemento.Value.ToString() });
            }

            return DropDownList;
        }
        #endregion

        #region Producción
        public static List<N_Folio_SIAC> GetProduccionPromotor(int idUsuario, string fechaInicial, string fechaFinal)
        {
            SO_Produccion ServicioProduccion = new SO_Produccion();

            List<N_Folio_SIAC> ListaResultante = new List<N_Folio_SIAC>();

            DataSet informacionBD = new DataSet();

            informacionBD = ServicioProduccion.GetProduccionPromotor(idUsuario, fechaInicial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        folio.FECHA_CAPTURA = element["FECHA_CAPTURA"].ToString();
                        folio.PROMOTOR = element["PROMOTOR"].ToString();
                        folio.ESTRATEGIA = element["ESTRATEGIA"].ToString();
                        folio.AREA = element["AREA"].ToString();
                        folio.FOLIO_SIAC = element["FOLIO_SIAC"].ToString();
                        folio.ESTATUS_SIAC = element["ESTATUS_SIAC"].ToString();
                        folio.TIPO_LINEA = element["TIPO_LINEA"].ToString();
                        folio.LINEA_CONTRATADA = element["LINEA_CONTRATADA"].ToString();
                        folio.PAQUETE = element["PAQUETE"].ToString();
                        folio.TELEFONO_ASIGNADO = element["TELEFONO_ASIGNADO"].ToString();
                        folio.ESTATUS_PISA_MULTIORDEN = element["ESTATUS_PISA_MULTIORDEN"].ToString();
                        folio.ORDEN_SERVICIO_TV = element["ORDEN_SERVICIO_TV"].ToString();

                        ListaResultante.Add(folio);
                    }
                }
            }

            return ListaResultante;
        }

        public static List<N_Folio_SIAC> GetProduccionGerente(int idUsuario, string fechaInicial, string fechaFinal)
        {
            SO_Produccion ServicioProduccion = new SO_Produccion();

            List<N_Folio_SIAC> ListaResultante = new List<N_Folio_SIAC>();

            DataSet informacionBD = new DataSet();

            informacionBD = ServicioProduccion.getProduccionGerente(idUsuario, fechaInicial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        folio.FECHA_CAPTURA = element["FECHA_CAPTURA"].ToString();
                        folio.PROMOTOR = element["PROMOTOR"].ToString();
                        folio.ESTRATEGIA = element["ESTRATEGIA"].ToString();
                        folio.AREA = element["AREA"].ToString();
                        folio.FOLIO_SIAC = element["FOLIO_SIAC"].ToString();
                        folio.ESTATUS_SIAC = element["ESTATUS_SIAC"].ToString();
                        folio.TIPO_LINEA = element["TIPO_LINEA"].ToString();
                        folio.LINEA_CONTRATADA = element["LINEA_CONTRATADA"].ToString();
                        folio.PAQUETE = element["PAQUETE"].ToString();
                        folio.TELEFONO_ASIGNADO = element["TELEFONO_ASIGNADO"].ToString();
                        folio.ESTATUS_PISA_MULTIORDEN = element["ESTATUS_PISA_MULTIORDEN"].ToString();
                        folio.ORDEN_SERVICIO_TV = element["ORDEN_SERVICIO_TV"].ToString();
                        folio.NombrePromotor = element["NOMBRE_PROMOTOR"].ToString();

                        ListaResultante.Add(folio);
                    }
                }
            }

            return ListaResultante;
        }

        public static double GetPosteadosVSProduccionGerente(int idPersona, string fechaInicial, string fechaFinal)
        {
            double pct = 0;

            SO_Produccion ServicioProduccion = new SO_Produccion();

            DataSet informacionBD = ServicioProduccion.GetPosteadosVSProducionGerente(idPersona, fechaInicial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        if (IsNumeric(item["PCT_POSTEADOS"].ToString()))
                        {
                            pct = Convert.ToDouble(item["PCT_POSTEADOS"].ToString() != null);
                        }
                        else
                            pct = 0;
                        
                    }
                }
            }

            return pct;
        }

        /// <summary>
        /// Método que indica si una cadena es un número.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static double GetPosteadosVSProduccionPromotor(int idPersona, string fechaIncial, string fechaFinal)
        {
            double pct = 0;

            SO_Produccion ServicioProduccion = new SO_Produccion();

            DataSet informacionBD = ServicioProduccion.GetPosteadosVSProduccionPromotor(idPersona, fechaIncial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        pct = Convert.ToDouble(item["PCT_POSTEADOS"].ToString());
                    }
                }
            }

            return pct;
        } 
        #endregion

        #region Nominas

        public static double GetNominaComisionesResumen()
        {
            SO_Nominas ServicioNominas = new SO_Nominas();

            double pagoNomina = 0;

            DataSet informarcionBD = ServicioNominas.GetNominaComisionResumen();

            if (informarcionBD != null)
            {
                if (informarcionBD.Tables.Count > 0 && informarcionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informarcionBD.Tables[0].Rows)
                    {
                        pagoNomina = Convert.ToDouble(item["PAGO_TOTAL_NOMINA"].ToString());
                    }
                }
            }

            return pagoNomina;
        }

        public static List<N_Folio_SIAC> GetNominaComisiones()
        {
            SO_Nominas ServicioNominas = new SO_Nominas();

            List<N_Folio_SIAC> ListaResultante = new List<N_Folio_SIAC>();

            DataSet informacionBD = ServicioNominas.GetNominasComision();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        N_Folio_SIAC folio = new N_Folio_SIAC();

                        folio.NombrePromotor = item["NOMBRE_USUARIO"].ToString();
                        folio.NoFolios = Convert.ToInt32(item["TOTAL_FOLIOS"].ToString());
                        folio.COMISION_TOTAL = Convert.ToDouble(item["PAGO"].ToString());

                        ListaResultante.Add(folio);
                    }
                }
            }

            return ListaResultante;
        }

        public static List<double> GetHistorialNominaPersona(int idPersona)
        {
            SO_Nominas ServicioNomina = new SO_Nominas();

            List<double> Lista = new List<double>();

            DataSet informacionBD = ServicioNomina.GetHistorialNominaPersona(idPersona);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count >= 1 && informacionBD.Tables[0].Rows.Count >= 1)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        Lista.Add(Convert.ToDouble(item["COMISION_TOTAL"].ToString()));
                    }
                }
            }

            return Lista;
        } 

        public static int SetPagoNominaComisiones(string nombreSemana)
        {
            SO_Nominas servicioNomina = new SO_Nominas();

            return servicioNomina.SetPagoComisiones(nombreSemana);
        }
        #endregion


    }
}