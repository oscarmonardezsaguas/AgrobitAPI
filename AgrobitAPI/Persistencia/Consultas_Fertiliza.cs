using AgrobitAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Persistencia
{
    public class Consultas_Fertiliza
    {
        Conexion con;

        public Consultas_Fertiliza(string db)
        {
            con = new Conexion(db);
        }

        public int CrearFertiliza(Fertiliza fertiliza)
        {
            int res = 0;

            string linea = "INSERT INTO Fertiliza (cuartelID, fecha, productoID, cantidad, temporada, norden) OUTPUT INSERTED.fertilizaID VALUES (@CI, @F, @PI, @C, @T, @NO)";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());
            consulta.Parameters.AddWithValue("@CI", fertiliza.cuartelID);
            consulta.Parameters.AddWithValue("@F", fertiliza.fecha);
            consulta.Parameters.AddWithValue("@PI", fertiliza.productoID);
            consulta.Parameters.AddWithValue("@C", fertiliza.cantidad);
            consulta.Parameters.AddWithValue("@T", fertiliza.temporada);
            consulta.Parameters.AddWithValue("@NO", fertiliza.norden);

            try
            {
                con.Abrir();
                res = (int)consulta.ExecuteScalar();

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw;
            } finally
            {
                con.Cerrar();
            }

            return res;
        }
    }
}
