using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Models
{
    public class Productor
    {
            public int Id { get; set; }

            public string ProductorRut { get; set; }

            public string ProductorNombre { get; set; }

            public string ProductorDireccion { get; set; }

            public string ProductorCorreo { get; set; }

            public string ProductorTelefono { get; set; }

            public string ProductorContacto { get; set; }

            public float ProductorSuperficieTotal { get; set; }

            public float ProductorSuperficiePlantada { get; set; }

            public float ProductorSuperficieAreaProtegida { get; set; }

            public float ProductorCorredorBiologico { get; set; }

            public int ProductorTipoEnergia { get; set; }

            public int ProductorSistemaHeladas { get; set; }

            public int ProductorTipoRiego { get; set; }

            public int ProductorFuenteAguaRiego { get; set; }

            public int ProductorFuenteAguaAplicacion { get; set; }

            public int ProductorNumeroTranques { get; set; }

            public int ProductorNumeroPozos { get; set; }

            public string ProductorLatitud { get; set; }

            public string ProductorLongitud { get; set; }

            public string _errormsg { get; set; }
    }
}
