using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoLideri.Models
{
    public class N_Folio_SIAC
    {
        public string FECHA_CAPTURA { get; set; }
        public string ESTRATEGIA { get; set; }
        public string PROMOTOR { get; set; }
        public string FOLIO_SIAC { get; set; }
        public string ESTATUS_SIAC { get; set; }
        public string TIPO_LINEA { get; set; }
        public string LINEA_CONTRATADA { get; set; }
        public string AREA { get; set; }
        public string DIVICION { get; set; }
        public string TIENDA { get; set; }
        public string PAQUETE { get; set; }
        public string OBSERVACIONES { get; set; }
        public string RESPUESTA_TELMEX { get; set; }
        public string MOTIVO_RECHAZO { get; set; }
        public string TELEFONO_ASIGNADO { get; set; }
        public string TELEFONO_PORTADO { get; set; }
        public string OS_ALTA_LINEA_MULTIORDEN { get; set; }
        public string FECHA_OS_ALTA_LINEA_MULTIORDEN { get; set; }
        public string ORDEN_SERVICIO_TV { get; set; }
        public string FECHA_OS_TV { get; set; }
        public string CAMPANA { get; set; }
        public string ESTATUS_ATENCION_MULTIORDEN { get; set; }
        public string ESTATUS_PISA_MULTIORDEN { get; set; }
        public string PISA_OS_FECHA_POSTEO_MULTIORDEN { get; set; }
        public string ESTATUS_PISA_TV { get; set; }
        public string PISA_OS_FECHA_POSTEO_TV { get; set; }
        public string FECHA_CAMBIO_ESTATUS_SIAC { get; set; }
        public string CLAVE_EMPRESA { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string SERVICIO_FACTURACION_TERCEROS { get; set; }
        public string ETAPA_PISA_MULTIORDEN { get; set; }
        public string ETAPA_PISA_TV { get; set; }
        public string ETIQUETA_TRAFICO_VOZ { get; set; }
        public string TRAFICO_VOZ_ENTRANTE { get; set; }
        public string TRAFICO_VOZ_SALIENTE { get; set; }
        public string FECHA_TRAFICO_VOZ { get; set; }
        public string TRAFICO_DATOS { get; set; }
        public string FECHA_TRAFICO_DATOS { get; set; }
        public string FECHA_FACTURCION { get; set; }
        public string DESCRIPCION_VALIDA_ADEUDO { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string ID { get; set; }
        public string Terminal { get; set; }
        public string Distrito { get; set; }
        public string TeCelular { get; set; }


        public bool ESTATUS_PAGADO { get; set; }
        public double COMISION_PAQUETE { get; set; }
        public double PORCENTAJE_COMISION { get; set; }
        public double COMISION_TOTAL { get; set; }
        public string NombrePromotor { get; set; }
        public int NoFolios { get; set; }
    }
}