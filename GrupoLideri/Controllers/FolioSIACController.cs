using GrupoLideri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

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
        public JsonResult upload(HttpPostedFileBase file)
        {
            StringBuilder strbuild = new StringBuilder();

            Excel.Application ExcelApp = null;
            Excel.Workbook ExcelWork = null;
            try
            {
                if (file.ContentLength == 0)
                    throw new Exception("Zero length file!");
                else
                {
                    var fileName = Path.GetFileName(file.FileName);
                    
                    var filePath = Path.Combine(Server.MapPath("~/Documents/Pipes"), "PIPES-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".xlsx");
                    
                    file.SaveAs(filePath);
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        string filename = filePath;

                        ExcelApp = new Excel.Application();
                        ExcelWork = ExcelApp.Workbooks.Open(filename, true);

                        foreach (Excel.Worksheet sheet in ExcelWork.Sheets)
                        {
                            //Obtenemos el rango de la hoja que estamos leyendo
                            Excel.Range range = sheet.UsedRange;

                            //Obtiene el número de filas de la hoja
                            int rowCount = range.Rows.Count;

                            int aux = 2;
                            while (aux <= rowCount)
                            {
                                N_Folio_SIAC obj = new N_Folio_SIAC();
                                obj.FECHA_CAPTURA = range.Cells[aux, 1].Value.ToString() != null ? range.Cells[aux, 1].Value.ToString() : string.Empty;
                                obj.ESTRATEGIA = range.Cells[aux, 2].Value.ToString() != null ? range.Cells[aux, 2].Value.ToString() : string.Empty;
                                obj.PROMOTOR = range.Cells[aux, 3].Value.ToString() != null ? range.Cells[aux, 3].Value.ToString() : string.Empty;
                                obj.FOLIO_SIAC = range.Cells[aux, 4].Value.ToString() != null ? range.Cells[aux, 4].Value.ToString() : string.Empty;
                                obj.ESTATUS_SIAC = range.Cells[aux, 5].Value.ToString() != null ? range.Cells[aux, 5].Value.ToString() : string.Empty;
                                obj.TIPO_LINEA = range.Cells[aux, 6].Value.ToString() != null ? range.Cells[aux, 6].Value.ToString() : string.Empty;
                                obj.LINEA_CONTRATADA = range.Cells[aux, 7].Value.ToString() != null ? range.Cells[aux, 7].Value.ToString() : string.Empty;
                                obj.AREA = range.Cells[aux, 8].Value.ToString() != null ? range.Cells[aux, 8].Value.ToString() : string.Empty;
                                obj.DIVICION = range.Cells[aux, 9].Value.ToString() != null ? range.Cells[aux, 9].Value.ToString() : string.Empty;
                                obj.TIENDA = range.Cells[aux, 10].Value.ToString() != null ? range.Cells[aux, 10].Value.ToString() : string.Empty;
                                obj.PAQUETE = range.Cells[aux, 11].Value.ToString() != null ? range.Cells[aux, 11].Value.ToString() : string.Empty;
                                obj.OBSERVACIONES = range.Cells[aux, 12].Value.ToString() != null ? range.Cells[aux, 12].Value.ToString() : string.Empty;
                                obj.RESPUESTA_TELMEX = range.Cells[aux, 13].Value.ToString() != null ? range.Cells[aux, 13].Value.ToString() : string.Empty;
                                obj.MOTIVO_RECHAZO = range.Cells[aux, 14].Value.ToString() != null ? range.Cells[aux, 14].Value.ToString() : string.Empty;
                                obj.TELEFONO_ASIGNADO = range.Cells[aux, 15].Value.ToString() != null ? range.Cells[aux, 15].Value.ToString() : string.Empty;
                                obj.TELEFONO_PORTADO = range.Cells[aux, 16].Value.ToString() != null ? range.Cells[aux, 16].Value.ToString() : string.Empty;
                                obj.OS_ALTA_LINEA_MULTIORDEN = range.Cells[aux, 17].Value.ToString() != null ? range.Cells[aux, 17].Value.ToString() : string.Empty;
                                obj.FECHA_OS_ALTA_LINEA_MULTIORDEN = range.Cells[aux, 18].Value.ToString() != null ? range.Cells[aux, 18].Value.ToString() : string.Empty;
                                obj.ORDEN_SERVICIO_TV = range.Cells[aux, 19].Value.ToString() != null ? range.Cells[aux, 19].Value.ToString() : string.Empty;
                                obj.FECHA_OS_TV = range.Cells[aux, 20].Value.ToString() != null ? range.Cells[aux, 20].Value.ToString() : string.Empty;
                                obj.CAMPANA = range.Cells[aux, 21].Value.ToString() != null ? range.Cells[aux, 21].Value.ToString() : string.Empty;
                                obj.ESTATUS_ATENCION_MULTIORDEN = range.Cells[aux, 22].Value.ToString() != null ? range.Cells[aux, 22].Value.ToString() : string.Empty;
                                obj.ESTATUS_PISA_MULTIORDEN = range.Cells[aux, 23].Value.ToString() != null ? range.Cells[aux, 23].Value.ToString() : string.Empty;
                                obj.PISA_OS_FECHA_POSTEO_MULTIORDEN = range.Cells[aux, 24].Value.ToString() != null ? range.Cells[aux, 24].Value.ToString() : string.Empty;
                                obj.ESTATUS_PISA_TV = range.Cells[aux, 25].Value.ToString() != null ? range.Cells[aux, 25].Value.ToString() : string.Empty;
                                obj.PISA_OS_FECHA_POSTEO_TV = range.Cells[aux, 26].Value.ToString() != null ? range.Cells[aux, 26].Value.ToString() : string.Empty;
                                obj.FECHA_CAMBIO_ESTATUS_SIAC = range.Cells[aux, 27].Value.ToString() != null ? range.Cells[aux, 27].Value.ToString() : string.Empty;
                                obj.CLAVE_EMPRESA = range.Cells[aux, 28].Value.ToString() != null ? range.Cells[aux, 28].Value.ToString() : string.Empty;
                                obj.NOMBRE_EMPRESA = range.Cells[aux, 29].Value.ToString() != null ? range.Cells[aux, 29].Value.ToString() : string.Empty;
                                obj.SERVICIO_FACTURACION_TERCEROS = range.Cells[aux, 30].Value.ToString() != null ? range.Cells[aux, 30].Value.ToString() : string.Empty;
                                obj.ETAPA_PISA_MULTIORDEN = range.Cells[aux, 31].Value.ToString() != null ? range.Cells[aux, 31].Value.ToString() : string.Empty;
                                obj.ETAPA_PISA_TV = range.Cells[aux, 32].Value.ToString() != null ? range.Cells[aux, 32].Value.ToString() : string.Empty;
                                obj.ETIQUETA_TRAFICO_VOZ = range.Cells[aux, 33].Value.ToString() != null ? range.Cells[aux, 33].Value.ToString() : string.Empty;
                                obj.TRAFICO_VOZ_ENTRANTE = range.Cells[aux, 34].Value.ToString() != null ? range.Cells[aux, 34].Value.ToString() : string.Empty;
                                obj.TRAFICO_VOZ_SALIENTE = range.Cells[aux, 35].Value.ToString() != null ? range.Cells[aux, 35].Value.ToString() : string.Empty;
                                obj.FECHA_TRAFICO_VOZ = range.Cells[aux, 36].Value.ToString() != null ? range.Cells[aux, 36].Value.ToString() : string.Empty;
                                obj.TRAFICO_DATOS = range.Cells[aux, 37].Value.ToString() != null ? range.Cells[aux, 37].Value.ToString() : string.Empty;
                                obj.FECHA_TRAFICO_DATOS = range.Cells[aux, 38].Value.ToString() != null ? range.Cells[aux, 38].Value.ToString() : string.Empty;
                                obj.FECHA_FACTURCION = range.Cells[aux, 39].Value.ToString() != null ? range.Cells[aux, 39].Value.ToString() : string.Empty;
                                obj.DESCRIPCION_VALIDA_ADEUDO = range.Cells[aux, 40].Value.ToString() != null ? range.Cells[aux, 40].Value.ToString() : string.Empty;
                                obj.CORREO_ELECTRONICO = range.Cells[aux, 41].Value.ToString() != null ? range.Cells[aux, 41].Value.ToString() : string.Empty;
                                obj.FECHA_NACIMIENTO = range.Cells[aux, 42].Value.ToString() != null ? range.Cells[aux, 42].Value.ToString() : string.Empty;
                                obj.ID = range.Cells[aux, 43].Value.ToString() != null ? range.Cells[aux, 43].Value.ToString() : string.Empty;
                                obj.Terminal = range.Cells[aux, 44].Value.ToString() != null ? range.Cells[aux, 44].Value.ToString() : string.Empty;
                                obj.Distrito = range.Cells[aux, 45].Value.ToString() != null ? range.Cells[aux, 45].Value.ToString() : string.Empty;
                                obj.TeCelular = range.Cells[aux, 46].Value.ToString() != null ? range.Cells[aux, 46].Value.ToString() : string.Empty;
                                
                                DataManager.InsertFolioSIAC(obj);
                                aux += 1;
                            }

                            ExcelWork.Close();
                            Marshal.ReleaseComObject(ExcelWork);
                            ExcelApp.Quit();
                            Marshal.ReleaseComObject(ExcelApp);
                        }
                    }
                }
                
            }
            catch (Exception er)
            {
                ExcelWork.Close();
                Marshal.ReleaseComObject(ExcelWork);
                ExcelApp.Quit();
                Marshal.ReleaseComObject(ExcelApp);
                
        }
            return new JsonResult()
            {
                Data = ""
            };
    }
    }
}