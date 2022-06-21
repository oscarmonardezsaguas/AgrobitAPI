using AgrobitAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Persistencia
{
    public class Consultas_Cuartel
    {
        Conexion con;

        public Consultas_Cuartel(string db)
        {
            con = new Conexion(db);
        }

        public List<Cuartel> GetCuartels()
        {
            List<Cuartel> lista = new List<Cuartel>();
            string linea = "SELECT c.CuartelID, c.CuartelDescripcion, c.ProductorID, c.ParcelaID, c.EspecieID, c.VariedadID, p.ProductorNombre, c.ha, c.m3ha, c.temporada FROM Cuartel c INNER JOIN Productor p ON p.ProductorID = c.ProductorID";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                SqlDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    Cuartel var = new Cuartel();
                    var.CuartelId = reader.GetInt32(0);
                    var.CuartelDescripcion = reader.GetString(1);
                    var.ProductorID = reader.GetInt32(2);
                    var.ParcelaID = reader.GetInt32(3);
                    var.EspecieID = reader.GetInt32(4);
                    var.VariedadID = reader.GetInt32(5);
                    var.ProductorNombre = reader.GetString(6);
                    var.ha = (float)reader.GetDouble(7);
                    var.m3ha = (float)reader.GetDouble(8);
                    var.temporada = reader.GetString(9);
                    lista.Add(var);
                }
            }
            catch (SqlException e)
            {

            }
            finally
            {
                con.Cerrar();
            }

            return lista;
        }
    }
}
