using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Persistencia
{
    public class Consultas_Temporada
    {
        Conexion con;
        public Consultas_Temporada(string db)
        {
            con = new Conexion(db);
        }

        public string GetTemporada()
        {
            string res = "";
            string linea = "SELECT codigo FROM Temporada WHERE activo = 1";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                object resultado = consulta.ExecuteScalar();
                res = resultado.ToString();
            }
            catch (SqlException e)
            {
                
            } finally
            {
                con.Cerrar();
            }

            return res;
        }
    }
}
