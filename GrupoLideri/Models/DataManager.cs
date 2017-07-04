using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.ServiceObject;
using Modelo;

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
            }
            return persona;
        }
        #endregion

        #region Folio
        public static bool InsertFolioSIAC(N_Folio_SIAC folio)
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
            n_folio.OS_ALTA_LINEA_MULTIORDEN = folio.OS_ALTA_LINEA_MULTIORDEN == "-" ? DateTime.MinValue.ToString() : folio.OS_ALTA_LINEA_MULTIORDEN;
            n_folio.PAQUETE = folio.PAQUETE;
            n_folio.PISA_OS_FECHA_POSTEO_MULTIORDEN = folio.PISA_OS_FECHA_POSTEO_MULTIORDEN == "-" ? DateTime.MinValue : Convert.ToDateTime(folio.PISA_OS_FECHA_POSTEO_MULTIORDEN);
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
            return ServicioFolio.InsertFolio(n_folio);

        } 
        #endregion
    }
}