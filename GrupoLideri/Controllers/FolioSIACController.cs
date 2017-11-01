using GrupoLideri.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoLideri.Controllers
{
    public class FolioSIACController : Controller
    {
        // GET: FolioSIAC
        [HttpGet]
        [GrupoLideriVerificarRol]
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult SubirPIPES(HttpPostedFileBase file)
        {
            try
            {
                if (file == null || file.ContentLength == 0)
                {
                    throw new Exception("Su archivo está vacío!");
                }
                else
                {
                    //Obtenemos el nombre del archivo.
                    var fileName = Path.GetFileName(file.FileName);

                    //Creamos el nombre con la ruta del archivo el cual va a subirse al servidor.
                    var filePath = Path.Combine(Server.MapPath("~/Documents/Pipes"), "PIPES-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".txt");

                    //Guardamos el archivo.
                    file.SaveAs(filePath);

                    if (!string.IsNullOrEmpty(filePath))
                    {

                        string pathToExcelFile = filePath;

                        StreamReader objReader = new StreamReader(filePath);

                        string a = objReader.ReadToEnd();

                        string aa = a.Substring(827, a.Length - 869);

                        string[] stringseparators = new string[] { "\r\n" };
                        string[] vector = aa.Split(stringseparators, StringSplitOptions.None);
                        List<string> vectorFinal = new List<string>();

                        int c = 0;

                        for (int i = 0; i < vector.Length - 1; i++)
                        {
                            string linea = vector[i];
                            if (linea.Length < 10 || !IsDate(linea.Substring(0, 10)))
                            {
                                vectorFinal[c - 1] = vectorFinal[c - 1] + linea;
                            }
                            else
                            {
                                vectorFinal.Add(linea);
                                c += 1;
                            }
                        }

                        List<N_Folio_SIAC> listaFolios = new List<N_Folio_SIAC>();

                        foreach (string item in vectorFinal)
                        {
                            string[] folio = item.Split('|');

                            if (folio.Length == 46)
                            {
                                N_Folio_SIAC siac = new N_Folio_SIAC();

                                siac.FECHA_CAPTURA = folio[0];
                                siac.ESTRATEGIA = folio[1];
                                siac.PROMOTOR = folio[2];
                                siac.FOLIO_SIAC = folio[3];
                                siac.ESTATUS_SIAC = folio[4];
                                siac.TIPO_LINEA = folio[5];
                                siac.LINEA_CONTRATADA = folio[6];
                                siac.AREA = folio[7];
                                siac.DIVICION = folio[8];
                                siac.TIENDA = folio[9];
                                siac.PAQUETE = folio[10];
                                siac.OBSERVACIONES = folio[11];
                                siac.RESPUESTA_TELMEX = folio[12];
                                siac.MOTIVO_RECHAZO = folio[13];
                                siac.TELEFONO_ASIGNADO = folio[14];
                                siac.TELEFONO_PORTADO = folio[15];
                                siac.OS_ALTA_LINEA_MULTIORDEN = folio[16];
                                siac.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio[17];
                                siac.ORDEN_SERVICIO_TV = folio[18];
                                siac.FECHA_OS_TV = folio[19];
                                siac.CAMPANA = folio[20];
                                siac.ESTATUS_ATENCION_MULTIORDEN = folio[21];
                                siac.ESTATUS_PISA_MULTIORDEN = folio[22];
                                siac.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio[23];
                                siac.ESTATUS_PISA_TV = folio[24];
                                siac.PISA_OS_FECHA_POSTEO_TV = folio[25];
                                siac.FECHA_CAMBIO_ESTATUS_SIAC = folio[26];
                                siac.CLAVE_EMPRESA = folio[27];
                                siac.NOMBRE_EMPRESA = folio[28];
                                siac.SERVICIO_FACTURACION_TERCEROS = folio[29];
                                siac.ETAPA_PISA_MULTIORDEN = folio[30];
                                siac.ETAPA_PISA_TV = folio[31];
                                siac.ETIQUETA_TRAFICO_VOZ = folio[32];
                                siac.TRAFICO_VOZ_ENTRANTE = folio[33];
                                siac.TRAFICO_VOZ_SALIENTE = folio[34];
                                siac.FECHA_TRAFICO_VOZ = folio[35];
                                siac.TRAFICO_DATOS = folio[36];
                                siac.FECHA_TRAFICO_DATOS = folio[37];
                                siac.FECHA_FACTURCION = folio[38];
                                siac.DESCRIPCION_VALIDA_ADEUDO = folio[39];
                                siac.CORREO_ELECTRONICO = folio[40];
                                siac.FECHA_NACIMIENTO = folio[41];
                                siac.ID = folio[42];
                                siac.Terminal = folio[43];
                                siac.Distrito = folio[44];
                                siac.TeCelular = folio[45];

                                DataManagerLideri.InsertOrUpdateFolioSIAC(siac);
                            }

                        }

                        
                    }
                }
                return Json("Archivo PIPES Actualizado correctamente");

            }
            catch (Exception)
            {
                return Json("Upps!, Se registro un error, por favor intente mas tarde.");
            }

            
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        //[System.Web.Mvc.HttpPost]
        //[GrupoLideriVerificarRol]
        //public ActionResult SubirPIPES(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        //Verificamos que el archivo contenga valores.
        //        if (file == null || file.ContentLength == 0)
        //            throw new Exception("Su archivo está vacío!");
        //        else
        //        {
        //            //Obtenemos el nombre del archivo.
        //            var fileName = Path.GetFileName(file.FileName);

        //            //Creamos el nombre con la ruta del archivo el cual va a subirse al servidor.
        //            var filePath = Path.Combine(Server.MapPath("~/Documents/Pipes"), "PIPES-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".xlsx");

        //            //Guardamos el archivo.
        //            file.SaveAs(filePath);

        //            //Verificamos que el nombre del archivo sea distinto de nulo o vació.
        //            if (!string.IsNullOrEmpty(filePath))
        //            {
        //                //Asignamos la ruta completa del archivo a una variable local.
        //                string pathToExcelFile = filePath;

        //                //Asignamos el nombre de la hoja del archivo del excel en donde se encuentra la inforamción.
        //                string sheetName = "PRODUCCION";

        //                //Mapeamos el archivo a una variable anónima.
        //                var excelFile = new ExcelQueryFactory(pathToExcelFile);

        //                //Obtenemos los registros de la hoja.
        //                var folios = from a in excelFile.Worksheet(sheetName) select a;

        //                //Iteramos todos los folios obtenidos.
        //                foreach (var folio in folios)
        //                {
        //                    //Declaramos un objeto de tipo N_Folio_SIAC que será el que insertaremos.
        //                    N_Folio_SIAC obj = new N_Folio_SIAC();

        //                    //Mapeamos los valores a las propiedades correspondientes.
        //                    obj.FECHA_CAPTURA = folio["Fecha Captura"];
        //                    obj.ESTRATEGIA = folio["Estrategia"];
        //                    obj.PROMOTOR = folio["Promotor"];
        //                    obj.FOLIO_SIAC = folio["Folio SIAC"];
        //                    obj.ESTATUS_SIAC = folio["Estatus SIAC"];
        //                    obj.TIPO_LINEA = folio["Tipo Linea"];
        //                    obj.LINEA_CONTRATADA = folio["Linea Contratada"];
        //                    obj.AREA = folio["Area"];
        //                    obj.DIVICION = folio["Division"];
        //                    obj.TIENDA = folio["Tienda"];
        //                    obj.PAQUETE = folio["Paquete"];
        //                    obj.OBSERVACIONES = folio["Observaciones"];
        //                    obj.RESPUESTA_TELMEX = folio["Respuesta Telmex"];
        //                    obj.MOTIVO_RECHAZO = folio["Motivo Rechazo "];
        //                    obj.TELEFONO_ASIGNADO = folio["Telefono Asignado"];
        //                    obj.TELEFONO_PORTADO = folio["Telefono Portado"];
        //                    obj.OS_ALTA_LINEA_MULTIORDEN = folio["OS Alta Linea o Multiorden"];
        //                    obj.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio["Fecha OS Alta Linea o Multiorden"];
        //                    obj.ORDEN_SERVICIO_TV = folio["Orden de Servicio TV"];
        //                    obj.FECHA_OS_TV = folio["Fecha de Os TV"];
        //                    obj.CAMPANA = folio["Campana"];
        //                    obj.ESTATUS_ATENCION_MULTIORDEN = folio["Estatus de Atención Multiorden"];
        //                    obj.ESTATUS_PISA_MULTIORDEN = folio["Estatus PISA Multiorden"];
        //                    obj.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio["Pisa OS Fecha POSTEO Multiorden"];
        //                    obj.ESTATUS_PISA_TV = folio["Estatus PISA TV"];
        //                    obj.PISA_OS_FECHA_POSTEO_TV = folio["Pisa OS Fecha POSTEO TV"];
        //                    obj.FECHA_CAMBIO_ESTATUS_SIAC = folio["Fecha cambio estatus SIAC"];
        //                    obj.CLAVE_EMPRESA = folio["Clave de Empresa"];
        //                    obj.NOMBRE_EMPRESA = folio["Nombre de Empresa"];
        //                    obj.SERVICIO_FACTURACION_TERCEROS = folio["Servicio de Facturación a Terceros"];
        //                    obj.ETAPA_PISA_MULTIORDEN = folio["Etapa PISA Multiorden"];
        //                    obj.ETAPA_PISA_TV = folio["Etapa PISA TV"];
        //                    obj.ETIQUETA_TRAFICO_VOZ = folio["Etiqueta Trafico Voz"];
        //                    obj.TRAFICO_VOZ_ENTRANTE = folio["Tráfico Voz Entrante"];
        //                    obj.TRAFICO_VOZ_SALIENTE = folio["Tráfico Voz Saliente"];
        //                    obj.FECHA_TRAFICO_VOZ = folio["Fecha tráfico voz"];
        //                    obj.TRAFICO_DATOS = folio["Tráfico Datos"];
        //                    obj.FECHA_TRAFICO_DATOS = folio["Fecha tráfico datos"];
        //                    obj.FECHA_FACTURCION = folio["Fecha Facturación"];
        //                    obj.DESCRIPCION_VALIDA_ADEUDO = folio["Descripción valida adeudo"];
        //                    obj.CORREO_ELECTRONICO = folio["Correo Electrónico"];
        //                    obj.FECHA_NACIMIENTO = folio["Fecha de nacimiento"];
        //                    obj.ID = folio["ID"];
        //                    obj.Terminal = folio["Terminal"];
        //                    obj.Distrito = folio["Distrito"];
        //                    obj.TeCelular = folio["TeCelular"];

        //                    //Ejecutamos el método el cual inserta el objeto en la base de datos.
        //                    DataManager.InsertOrUpdateFolioSIAC(obj);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception er)
        //    {
        //        string a = er.Message;
        //        Session["MENSAJE"] = er.Message;
        //    }

        //    //Retornamos a la vista inicial.
        //    return View("Index");
        //}

        //[System.Web.Mvc.HttpPost]
        //[GrupoLideriVerificarRol]
        //public ActionResult SubirPIPES()
        //{
        //    try
        //    {
        //        var file = Request.Files[0];
        //        //Verificamos que el archivo contenga valores.
        //        if (file == null || file.ContentLength == 0)
        //            throw new Exception("Su archivo está vacío!");
        //        else
        //        {
        //            //Obtenemos el nombre del archivo.
        //            var fileName = Path.GetFileName(file.FileName);

        //            //Creamos el nombre con la ruta del archivo el cual va a subirse al servidor.
        //            var filePath = Path.Combine(Server.MapPath("~/Documents/Pipes"), "PIPES-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".xlsx");

        //            //Guardamos el archivo.
        //            file.SaveAs(filePath);

        //            //Verificamos que el nombre del archivo sea distinto de nulo o vació.
        //            if (!string.IsNullOrEmpty(filePath))
        //            {
        //                //Asignamos la ruta completa del archivo a una variable local.
        //                string pathToExcelFile = filePath;

        //                //Asignamos el nombre de la hoja del archivo del excel en donde se encuentra la inforamción.
        //                string sheetName = "PRODUCCION";

        //                //Mapeamos el archivo a una variable anónima.
        //                var excelFile = new ExcelQueryFactory(pathToExcelFile);

        //                //Obtenemos los registros de la hoja.
        //                var folios = from a in excelFile.Worksheet(sheetName) select a;

        //                //Iteramos todos los folios obtenidos.
        //                foreach (var folio in folios)
        //                {
        //                    //Declaramos un objeto de tipo N_Folio_SIAC que será el que insertaremos.
        //                    N_Folio_SIAC obj = new N_Folio_SIAC();

        //                    //Mapeamos los valores a las propiedades correspondientes.
        //                    obj.FECHA_CAPTURA = folio["Fecha Captura"];
        //                    obj.ESTRATEGIA = folio["Estrategia"];
        //                    obj.PROMOTOR = folio["Promotor"];
        //                    obj.FOLIO_SIAC = folio["Folio SIAC"];
        //                    obj.ESTATUS_SIAC = folio["Estatus SIAC"];
        //                    obj.TIPO_LINEA = folio["Tipo Linea"];
        //                    obj.LINEA_CONTRATADA = folio["Linea Contratada"];
        //                    obj.AREA = folio["Area"];
        //                    obj.DIVICION = folio["Division"];
        //                    obj.TIENDA = folio["Tienda"];
        //                    obj.PAQUETE = folio["Paquete"];
        //                    obj.OBSERVACIONES = folio["Observaciones"];
        //                    obj.RESPUESTA_TELMEX = folio["Respuesta Telmex"];
        //                    obj.MOTIVO_RECHAZO = folio["Motivo Rechazo "];
        //                    obj.TELEFONO_ASIGNADO = folio["Telefono Asignado"];
        //                    obj.TELEFONO_PORTADO = folio["Telefono Portado"];
        //                    obj.OS_ALTA_LINEA_MULTIORDEN = folio["OS Alta Linea o Multiorden"];
        //                    obj.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio["Fecha OS Alta Linea o Multiorden"];
        //                    obj.ORDEN_SERVICIO_TV = folio["Orden de Servicio TV"];
        //                    obj.FECHA_OS_TV = folio["Fecha de Os TV"];
        //                    obj.CAMPANA = folio["Campana"];
        //                    obj.ESTATUS_ATENCION_MULTIORDEN = folio["Estatus de Atención Multiorden"];
        //                    obj.ESTATUS_PISA_MULTIORDEN = folio["Estatus PISA Multiorden"];
        //                    obj.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio["Pisa OS Fecha POSTEO Multiorden"];
        //                    obj.ESTATUS_PISA_TV = folio["Estatus PISA TV"];
        //                    obj.PISA_OS_FECHA_POSTEO_TV = folio["Pisa OS Fecha POSTEO TV"];
        //                    obj.FECHA_CAMBIO_ESTATUS_SIAC = folio["Fecha cambio estatus SIAC"];
        //                    obj.CLAVE_EMPRESA = folio["Clave de Empresa"];
        //                    obj.NOMBRE_EMPRESA = folio["Nombre de Empresa"];
        //                    obj.SERVICIO_FACTURACION_TERCEROS = folio["Servicio de Facturación a Terceros"];
        //                    obj.ETAPA_PISA_MULTIORDEN = folio["Etapa PISA Multiorden"];
        //                    obj.ETAPA_PISA_TV = folio["Etapa PISA TV"];
        //                    obj.ETIQUETA_TRAFICO_VOZ = folio["Etiqueta Trafico Voz"];
        //                    obj.TRAFICO_VOZ_ENTRANTE = folio["Tráfico Voz Entrante"];
        //                    obj.TRAFICO_VOZ_SALIENTE = folio["Tráfico Voz Saliente"];
        //                    obj.FECHA_TRAFICO_VOZ = folio["Fecha tráfico voz"];
        //                    obj.TRAFICO_DATOS = folio["Tráfico Datos"];
        //                    obj.FECHA_TRAFICO_DATOS = folio["Fecha tráfico datos"];
        //                    obj.FECHA_FACTURCION = folio["Fecha Facturación"];
        //                    obj.DESCRIPCION_VALIDA_ADEUDO = folio["Descripción valida adeudo"];
        //                    obj.CORREO_ELECTRONICO = folio["Correo Electrónico"];
        //                    obj.FECHA_NACIMIENTO = folio["Fecha de nacimiento"];
        //                    obj.ID = folio["ID"];
        //                    obj.Terminal = folio["Terminal"];
        //                    obj.Distrito = folio["Distrito"];
        //                    obj.TeCelular = folio["TeCelular"];

        //                    //Ejecutamos el método el cual inserta el objeto en la base de datos.
        //                    //DataManager.InsertOrUpdateFolioSIAC(obj);

        //                    //Ejecutamos el método el cual inserta el objeto en la base de datos.
        //                    DataManagerLideri.InsertOrUpdateFolioSIAC(obj);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception er)
        //    {
        //        string a = er.Message;
        //        Session["MENSAJE"] = er.Message;
        //    }

        //    //Retornamos a la vista inicial.
        //    return View("Index");
        //}
    }
}