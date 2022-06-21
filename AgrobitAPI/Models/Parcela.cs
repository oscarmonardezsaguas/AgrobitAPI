using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Models
{
    public class Parcela
    {
        public int parcelaID { get; set; }

        public string parcelaNombre { get; set; }

        public int productorID { get; set; }

        public int parcelaSAG { get; set; }

        public string parcelaCoord { get; set; }
    }
}
