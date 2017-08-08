using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoLideri.Models
{
    public class DO_Item_Chart
    {
        public int Id { get; set; }
        public int parentId { get; set; }
        public string Name { get; set; }
    }
}