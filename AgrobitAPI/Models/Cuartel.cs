namespace AgrobitAPI.Models
{
    public class Cuartel
    {
        public string db { get; set; }

        public int CuartelId { get; set; }

        public string CuartelDescripcion { get; set; }

        public int ProductorID { get; set; }

        public int ParcelaID { get; set; }

        public int EspecieID { get; set; }

        public int VariedadID { get; set; }

        public float ha { get; set; }

        public float m3ha { get; set; }

        public string temporada { get; set; }

        public string ProductorNombre { get; set; }

        public string EspecieNombre { get; set; }

        public string _errormsg { get; set; }

    }
}