using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AgrobitAPI.Models;

namespace AgrobitAPI.Persistencia
{
    public class Consultas_Producto
    {
        Conexion con;

        public Consultas_Producto(string db)
        {
            con = new Conexion(db);
        }

        public List<Producto> getProductos()
        {
            List<Producto> lista = new List<Producto>();
            string linea = "SELECT idProducto, codigoProducto, NombreProducto FROM Producto";
            SqlCommand consulta = new SqlCommand(linea, con.getConexion());

            try
            {
                con.Abrir();
                SqlDataReader reader = consulta.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.idProducto = reader.GetInt32(0);
                    producto.codigoProducto = reader.GetInt32(1);
                    producto.nombreProducto = reader.GetString(2);

                    lista.Add(producto);
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
    }
}
