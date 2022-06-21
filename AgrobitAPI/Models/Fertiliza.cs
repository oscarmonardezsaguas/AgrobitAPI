using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Models
{
    public class Fertiliza
    {
        public int fertilizaID { get; set; }

        public int cuartelID { get; set; }

        public DateTime fecha { get; set; }

        public int productoID { get; set; }

        public string cantidad { get; set; }

        public int temporada { get; set; }

        public int norden { get; set; }
    }
}
