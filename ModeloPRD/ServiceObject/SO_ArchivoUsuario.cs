using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_ArchivoUsuario
    {
        public int Insert(byte[] archivo, int idUsuario)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    TBL_ARCHIVO_USUARIO objArchivo = new TBL_ARCHIVO_USUARIO();

                    objArchivo.ARCHIVO = archivo;
                    objArchivo.FECHA_CREACION = DateTime.Now;
                    objArchivo.ID_USUARIO = idUsuario;

                    Conexion.TBL_ARCHIVO_USUARIO.Add(objArchivo);

                    int r = Conexion.SaveChanges();

                    return r;

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public byte[] GetArchivo(int idArchivo)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    byte[] Lista = (from a in Conexion.TBL_ARCHIVO_USUARIO
                                 where a.ID_ARCHIVO_USUARIO == idArchivo
                                 select a.ARCHIVO).FirstOrDefault();
                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetArchivosUsuario(int idPersona)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var ListaArchivos = (from a in Conexion.TBL_ARCHIVO_USUARIO
                                         where a.ID_USUARIO == idPersona
                                         select a).ToList();

                    return ListaArchivos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
