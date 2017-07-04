using GrupoLideri.Models;
using LinqToExcel;
using System;
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
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SubirPIPES(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength == 0)
                    throw new Exception("Su archivo esta vacío!");
                else
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Documents/Pipes"), "PIPES-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".xlsx");
                    file.SaveAs(filePath);

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        string pathToExcelFile = filePath;

                        string sheetName = "PRODUCCION";

                        var excelFile = new ExcelQueryFactory(pathToExcelFile);
                        var folios = from a in excelFile.Worksheet(sheetName) select a;

                        foreach (var folio in folios)
                        {
                            N_Folio_SIAC obj = new N_Folio_SIAC();
                            obj.FECHA_CAPTURA = folio["Fecha Captura"];
                            obj.ESTRATEGIA = folio["Estrategia"];
                            obj.PROMOTOR = folio["Promotor"];
                            obj.FOLIO_SIAC = folio["Folio SIAC"];
                            obj.ESTATUS_SIAC = folio["Estatus SIAC"];
                            obj.TIPO_LINEA = folio["Tipo Linea"];
                            obj.LINEA_CONTRATADA = folio["Linea Contratada"];
                            obj.AREA = folio["Area"];
                            obj.DIVICION = folio["Division"];
                            obj.TIENDA = folio["Tienda"];
                            obj.PAQUETE = folio["Paquete"];
                            obj.OBSERVACIONES = folio["Observaciones"];
                            obj.RESPUESTA_TELMEX = folio["Respuesta Telmex"];
                            obj.MOTIVO_RECHAZO = folio["Motivo Rechazo "];
                            obj.TELEFONO_ASIGNADO = folio["Telefono Asignado"];
                            obj.TELEFONO_PORTADO = folio["Telefono Portado"];
                            obj.OS_ALTA_LINEA_MULTIORDEN = folio["OS Alta Linea o Multiorden"];
                            obj.FECHA_OS_ALTA_LINEA_MULTIORDEN = folio["Fecha OS Alta Linea o Multiorden"];
                            obj.ORDEN_SERVICIO_TV = folio["Orden de Servicio TV"];
                            obj.FECHA_OS_TV = folio["Fecha de Os TV"];
                            obj.CAMPANA = folio["Campana"];
                            obj.ESTATUS_ATENCION_MULTIORDEN = folio["Estatus de Atención Multiorden"];
                            obj.ESTATUS_PISA_MULTIORDEN = folio["Estatus PISA Multiorden"];
                            obj.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio["Pisa OS Fecha POSTEO Multiorden"];
                            obj.ESTATUS_PISA_TV = folio["Estatus PISA TV"];
                            obj.PISA_OS_FECHA_POSTEO_TV = folio["Pisa OS Fecha POSTEO TV"];
                            obj.FECHA_CAMBIO_ESTATUS_SIAC = folio["Fecha cambio estatus SIAC"];
                            obj.CLAVE_EMPRESA = folio["Clave de Empresa"];
                            obj.NOMBRE_EMPRESA = folio["Nombre de Empresa"];
                            obj.SERVICIO_FACTURACION_TERCEROS = folio["Servicio de Facturación a Terceros"];
                            obj.ETAPA_PISA_MULTIORDEN = folio["Etapa PISA Multiorden"];
                            obj.ETAPA_PISA_TV = folio["Etapa PISA TV"];
                            obj.ETIQUETA_TRAFICO_VOZ = folio["Etiqueta Trafico Voz"];
                            obj.TRAFICO_VOZ_ENTRANTE = folio["Tráfico Voz Entrante"];
                            obj.TRAFICO_VOZ_SALIENTE = folio["Tráfico Voz Saliente"];
                            obj.FECHA_TRAFICO_VOZ = folio["Fecha tráfico voz"];
                            obj.TRAFICO_DATOS = folio["Tráfico Datos"];
                            obj.FECHA_TRAFICO_DATOS = folio["Fecha tráfico datos"];
                            obj.FECHA_FACTURCION = folio["Fecha Facturación"];
                            obj.DESCRIPCION_VALIDA_ADEUDO = folio["Descripción valida adeudo"];
                            obj.CORREO_ELECTRONICO = folio["Correo Electrónico"];
                            obj.FECHA_NACIMIENTO = folio["Fecha de nacimiento"];
                            obj.ID = folio["ID"];
                            obj.Terminal = folio["Terminal"];
                            obj.Distrito = folio["Distrito"];
                            obj.TeCelular = folio["TeCelular"];
                            DataManager.InsertOrUpdateFolioSIAC(obj);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                string a = er.Message;
            }

            return View("Index");
        }
    }
}