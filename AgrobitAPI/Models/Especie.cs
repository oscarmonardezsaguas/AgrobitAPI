using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Models
{
    public class Especie
    {
        public int id { get; set; }

        public int especiecodigo { get; set; }

        public string especienombre { get; set; }

        public string especiecodigosag { get; set; }

        public string _errormsg { get; set; }
    }
}
