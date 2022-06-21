using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Persistencia
{
    public class Conexion
    {
        SqlConnection conexion;

        public Conexion(string db)
        {
            string servidor = "Data Source= tcp:svragrobit.database.windows.net,1433;";
            string bd = "Initial Catalog=" + db + ";";
            conexion = new SqlConnection(servidor + bd + "Persist Security Info=False;User ID=ServerAgrobit;Password=Agrobit.,123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public SqlConnection getConexion()
        {
            return conexion;
        }

        public bool Abrir()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public void Cerrar()
        {
            conexion.Close();
        }
    }
}
