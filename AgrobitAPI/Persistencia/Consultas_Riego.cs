using AgrobitAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgrobitAPI.Persistencia
{
    public class Consultas_Riego
    {
        Conexion con;
        public Consultas_Riego(string db)
        {
            con = new Conexion(db);
        }

        public List<Productor> getProductores()
        {
            List<Productor> lista = new List<Productor>();
            string linea = "SELECT productorID, productorNombre FROM Productor";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                SqlDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    Productor productor = new Productor();
                    productor.Id = reader.GetInt32(0);
                    productor.ProductorNombre = reader.GetString(1);
                    lista.Add(productor);
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

        public List<Parcela> getParcelas()
        {
            List<Parcela> lista = new List<Parcela>();
            string linea = "SELECT parcelaID, parcelaNombre, productorID, parcelaSAG FROM Parcela";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                SqlDataReader reader = consulta.ExecuteReader();
                while (reader.Read())
                {
                    Parcela parcela = new Parcela();
                    parcela.parcelaID = reader.GetInt32(0);
                    parcela.parcelaNombre = reader.GetString(1);
                    parcela.productorID = reader.GetInt32(2);
                    parcela.parcelaSAG = reader.GetInt32(3);

                    lista.Add(parcela);
                }
            }
            catch (SqlException e)
            {
                Console.Write(e);
            }
            finally
            {
                con.Cerrar();
            }
            return lista;
        }

        public List<Especie> getEspecies()
        {
            List<Especie> lista = new List<Especie>();
            string linea = "SELECT * FROM Especie";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                SqlDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    Especie esp = new Especie();
                    esp.id = reader.GetInt32(0);
                    esp.especiecodigo = reader.GetInt32(1);
                    esp.especienombre = reader.GetString(2);
                    esp.especiecodigosag = reader.GetString(3);

                    lista.Add(esp);
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

        public int CrearRiego(Riego riego)
        {
            int res = 0;

            SqlCommand consulta = new SqlCommand("spp_actualizariego", con.getConexion());
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id", 0);
            consulta.Parameters.AddWithValue("@productorID", riego.ProductorID);
            consulta.Parameters.AddWithValue("@cuartelID", riego.CuartelID);
            consulta.Parameters.AddWithValue("@especieID", riego.EspecieID);
            consulta.Parameters.AddWithValue("@parcelaID", riego.ParcelaID);
            consulta.Parameters.AddWithValue("@fecha", riego.Fecha);
            consulta.Parameters.AddWithValue("@norden", riego.NOrden);
            consulta.Parameters.AddWithValue("@minutos", riego.Minutos);
            consulta.Parameters.AddWithValue("@temporada", riego.Temporada);
            consulta.Parameters.AddWithValue("@estado", 0);

            try
            {
                con.Abrir();
                res = (int)consulta.ExecuteScalar();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                con.Cerrar();
            }

            return res;
        }

        public int GetOrden()
        {
            int res = 0;
            SqlCommand consulta = new SqlCommand("spp_ordenriego", con.getConexion());
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Abrir();
                res = (int)consulta.ExecuteScalar();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                con.Cerrar();
            }

            return res;
        }
    }
   
}
