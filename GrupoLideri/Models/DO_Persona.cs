using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoLideri.Models
{
    public class DO_Persona
    {
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int idJerarquia { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Matricula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime fechaNacimiento { get; set; }

        //JefeId
        public int parentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}