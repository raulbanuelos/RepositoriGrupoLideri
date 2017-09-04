using ModeloPRD.SQLServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ModeloPRD.ServiceObject
{
    public class SO_Persona
    {
        public TBL_USUARIO Login(string usuario, string contrasena)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    var persona = (from p in Contexto.TBL_USUARIO
                                   where p.CONTRASENA == contrasena && p.USUARIO == usuario && p.CHECK_RH == true
                                   select p).ToList().FirstOrDefault();

                    return persona;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }
        
        public int Insert(string materno, string paterno, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string CURP)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    TBL_USUARIO persona = new TBL_USUARIO();

                    persona.APELLIDO_MATERNO = materno;
                    persona.APELLIDO_PATERNO = paterno;
                    persona.CONTRASENA = String.Empty;
                    persona.EMAIL = email;
                    persona.FECHA_NACIMIENTO = fechaNacimiento;
                    persona.ID_JEFE = idJefe;
                    persona.ID_JERARQUIA = idJerarquia;
                    persona.NOMBRE = nombre;
                    persona.RFC = rfc;
                    persona.CURP = CURP;
                    persona.TELEFONO = telefono;
                    persona.USUARIO = String.Empty;
                    persona.FECHA_CREACION = DateTime.Now;
                    persona.FECHA_ACTUALIZACION = DateTime.Now;
                    persona.CHECK_RH = false;
                    Contexto.TBL_USUARIO.Add(persona);
                    return Contexto.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }
        
        public int Update(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string nombre, string rfc, string telefono, string usuario,int idUsuario, string CURP, bool checkRH)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    TBL_USUARIO usuariobd = Conexion.TBL_USUARIO.Where(x => x.ID_USUARIO == idUsuario).FirstOrDefault();

                    usuariobd.APELLIDO_MATERNO = materno;
                    usuariobd.APELLIDO_PATERNO = paterno;
                    usuariobd.CONTRASENA = contrasena;
                    usuariobd.EMAIL = email;
                    usuariobd.FECHA_NACIMIENTO = fechaNacimiento;
                    usuariobd.ID_JEFE = idJefe;
                    usuariobd.ID_JERARQUIA = idJerarquia;
                    usuariobd.NOMBRE = nombre;
                    usuariobd.RFC = rfc;
                    usuariobd.CURP = CURP;
                    usuariobd.TELEFONO = telefono;
                    usuariobd.USUARIO = usuario;
                    usuariobd.FECHA_ACTUALIZACION = DateTime.Now;
                    usuariobd.CHECK_RH = checkRH;

                    Conexion.Entry(usuariobd).State = EntityState.Modified;

                    return Conexion.SaveChanges();

                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        public int Delete(int idUsuario)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    TBL_USUARIO usuario = Conexion.TBL_USUARIO.Where(x => x.ID_USUARIO == idUsuario).FirstOrDefault();

                    Conexion.Entry(usuario).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        public IList GetUsuario(int idUsuario)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var usuario = (from a in Conexion.TBL_USUARIO
                                   where a.ID_USUARIO == idUsuario
                                   select a).ToList();

                    return usuario;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }

        public int AsignarCvePromotor(int idUsuario, string cvePromotor)
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    TBL_CLAVE_PROMOTOR clave = new TBL_CLAVE_PROMOTOR();

                    clave.CLAVE_PROMOTOR = cvePromotor;
                    clave.FECHA_CREACION = DateTime.Now;
                    clave.ID_USUARIO = idUsuario;

                    Conexion.TBL_CLAVE_PROMOTOR.Add(clave);

                    return Conexion.SaveChanges();
                    
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        public IList ExistsMatricula(string cvePromotor)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    var persona = (from p in Contexto.TBL_CLAVE_PROMOTOR
                             where p.CLAVE_PROMOTOR == cvePromotor
                             select p).ToList();

                    return persona;
                }
            }
            catch (Exception er)
            {

                throw;
            }
        }

        public IList GetUsuarios()
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var ListaUsuarios = (from a in Conexion.TBL_USUARIO
                                         select a).OrderBy(x => x.NOMBRE).ToList();

                    return ListaUsuarios;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }

        public IList GetUsuariosPendienteClavePromotor()
        {
            try
            {
                using (var Conexion = new JudaPRDEntities())
                {
                    var ListaUsuario = (from a in Conexion.TBL_USUARIO
                                        where a.CHECK_RH == false
                                        select a).ToList();

                    return ListaUsuario;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }

    }
}
