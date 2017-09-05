using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoLideri.Models
{
    public class DO_Archivo
    {
        public byte[] ArchivoFisico { get; set; }
        public string NombreArchivo { get; set; }
        public int idArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}