using Modelo.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ServiceObject
{
    public class SO_Persona
    {
        /// <summary>
        /// Método que busca algún registro que conincida con el usuario y la contraseña recibida en el parámetro.
        /// </summary>
        /// <param name="usuario">Cadena que representa el usuario que se requiere buscar.</param>
        /// <param name="contrasena">Cadena que representa la contraseña que se requiere buscar.</param>
        /// <returns>Retorna un true si existe un registro con el usuario y la contraseña enviadas a los parámetros, de lo contrario renorna un false.</returns>
        public TBL_USUARIOS Login(string usuario, string contrasena)
        {
            //Ejemplo
            try
            {
                //Inicializamos la conexión a la base de datos a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Realizamos la consulta.
                    var persona = (from p in Contexto.TBL_USUARIOS
                                   where p.CONTRASENA == contrasena && p.USUARIO == usuario
                                   select p).ToList().FirstOrDefault();

                    //Retornamos el resultado de la consulta.
                    return persona;
                }
            }
            catch (Exception er)
            {
                //Registrar error en base de datos.
                return null;
            }
        }

        public DataSet GetOrganigrama(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("IdUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure("SP_ORG_GetOrganigrama", parametros);

                return datos;
            }
            catch (Exception er)
            {
                return null;
            }

        }

        public DataSet InsertOrUpdateOrDeletePersona(int idJeraquia, string usuario, string contrasena, string nombre, string aPaterno, string aMaterno, string fechaNacimiento, string rfc, string matricula, int idJefe, string Area, string estrategia, int activo,string direccionOficina, string telefonoOficina, string nombreRentero, string telefonoRentero, string usuarioCreo, int opcion, int idUsuario = 0, int factura = 0, string ctaCoppel = "", string cveInterbancaria = "", string ctaSaldazo = "", string ctaBanorte = "")
        {
            try
            {
                DataSet datos = null;

                GrupoLideri_SQL conexion = new GrupoLideri_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("ID_USUARIO", idUsuario);
                parametros.Add("ID_JERARQUIA", idJeraquia);
                parametros.Add("USUARIO", usuario);
                parametros.Add("CONTRASENA", contrasena);
                parametros.Add("NOMBRE",nombre);
                parametros.Add("APELLIDO_PATERNO",aPaterno);
                parametros.Add("APELLIDO_MATERNO", aMaterno);
                parametros.Add("FECHA_NACIMIENTO",fechaNacimiento);
                parametros.Add("RFC",rfc);
                parametros.Add("MATRICULA", matricula);
                parametros.Add("JEFEID",idJefe);
                parametros.Add("FACTURA", factura);
                parametros.Add("AREA", Area);
                parametros.Add("ESTRATEGIA", estrategia);
                parametros.Add("CTA_COPPEL", ctaCoppel);
                parametros.Add("CVE_INTERBANCARIA",cveInterbancaria);
                parametros.Add("CTA_SALDAZO",ctaSaldazo);
                parametros.Add("CTA_BANORTE",ctaBanorte);
                parametros.Add("ACTIVO", activo);
                parametros.Add("DIRECCION_OFICINA", direccionOficina);
                parametros.Add("TELEFONO_OFICINA", telefonoOficina);
                parametros.Add("NOMBRE_RENTERO",nombreRentero);
                parametros.Add("TELEFONO_RENTERO",telefonoRentero);
                parametros.Add("USUARIO_ADD_UPDATE",usuarioCreo);
                parametros.Add("OPCION",opcion);
                return datos = conexion.EjecutarStoredProcedure("InsertOrUpdateOrDeleteTBL_USUARIOS", parametros);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
