using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Models
{
    public class Riego
    {
        public string db { get; set; }

        public int id { get; set; }

        public int ProductorID { get; set; }

        public int ParcelaID { get; set; }

        public int CuartelID { get; set; }

        public int EspecieID { get; set; }

        public DateTime Fecha { get; set; }

        public string Minutos { get; set; }

        public string M3 { get; set; }

        public string Temporada { get; set; }

        public int NOrden { get; set; }
    }
}
