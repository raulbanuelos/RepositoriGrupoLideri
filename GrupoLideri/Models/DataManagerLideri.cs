using ModeloPRD;
using ModeloPRD.ServiceObject;
using System;
using System.Collections;
using System.Collections.Generic;
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
                    persona.idPersona = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.Matricula = (string)tipo.GetProperty("MATRICULA").GetValue(item, null);
                    persona.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    persona.Telefono = (string)tipo.GetProperty("TELEFONO").GetValue(item, null);
                    persona.fechaNacimiento = (DateTime)tipo.GetProperty("FECHA_NACIMIENTO").GetValue(item,null);
                    persona.Email = (string)tipo.GetProperty("EMAIL").GetValue(item, null);
                    
                }
            }

            return persona;
        }

        public static int InsertUsuario(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario,string CURP)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Insert(materno, paterno, contrasena, email, fechaNacimiento, idJefe, idJerarquia, nombre, rfc, telefono, usuario,CURP);
        }

        public static int UpdateUsuario(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario,int idUsuario,string CURP)
        {
            SO_Persona ServicioPersona = new SO_Persona();

            return ServicioPersona.Update(materno, paterno, contrasena, email, fechaNacimiento, idJefe, idJerarquia, nombre, rfc, telefono, usuario, idUsuario,CURP);
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

        #region Jerarquias
        public static List<FO_Item_Combo> GetJearaquias()
        {
            SO_Jerarquia ServicioJerarquia = new SO_Jerarquia();

            List<FO_Item_Combo> ListaResultante = new List<FO_Item_Combo>();

            IList informacionBD = ServicioJerarquia.GetJerarquias();

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
        #endregion
        
        public static List<SelectListItem> ToDropdownListFromItemCombo(List<FO_Item_Combo> lista)
        {
            List<SelectListItem> DropDownList = new List<SelectListItem>();

            foreach (FO_Item_Combo elemento in lista)
            {
                DropDownList.Add(new SelectListItem { Text = elemento.Text, Value = elemento.Value.ToString() });
            }

            return DropDownList;
        }
    }
}