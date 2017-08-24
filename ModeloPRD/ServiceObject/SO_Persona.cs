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
                                   where p.CONTRASENA == contrasena && p.USUARIO == usuario
                                   select p).ToList().FirstOrDefault();

                    return persona;
                }
            }
            catch (Exception er)
            {
                return null;
            }
        }
        
        public int Insert(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string matricula, string nombre, string rfc, string telefono, string usuario)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    TBL_USUARIO persona = new TBL_USUARIO();

                    persona.APELLIDO_MATERNO = materno;
                    persona.APELLIDO_PATERNO = paterno;
                    persona.CONTRASENA = contrasena;
                    persona.EMAIL = email;
                    persona.FECHA_NACIMIENTO = fechaNacimiento;
                    persona.ID_JEFE = idJefe;
                    persona.ID_JERARQUIA = idJerarquia;
                    persona.MATRICULA = matricula;
                    persona.NOMBRE = nombre;
                    persona.RFC = rfc;
                    persona.TELEFONO = telefono;
                    persona.USUARIO = usuario;
                    persona.FECHA_CREACION = DateTime.Now;
                    persona.FECHA_ACTUALIZACION = DateTime.Now;
                    Contexto.TBL_USUARIO.Add(persona);
                    return Contexto.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        public int Update(string materno, string paterno, string contrasena, string email, DateTime fechaNacimiento, int idJefe, int idJerarquia, string matricula, string nombre, string rfc, string telefono, string usuario,int idUsuario)
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
                    usuariobd.MATRICULA = matricula;
                    usuariobd.NOMBRE = nombre;
                    usuariobd.RFC = rfc;
                    usuariobd.TELEFONO = telefono;
                    usuariobd.USUARIO = usuario;
                    usuariobd.FECHA_ACTUALIZACION = DateTime.Now;

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
        
        public IList ExistsMatricula(string matricula)
        {
            try
            {
                using (var Contexto = new JudaPRDEntities())
                {
                    var persona = (from p in Contexto.TBL_USUARIO
                                   where p.MATRICULA == matricula
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

    }
}
