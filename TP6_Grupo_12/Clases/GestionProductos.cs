using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace TP6_Grupo_12.Clases
{
    public class GestionProductos
    {
        public GestionProductos() 
        {

        }

        public DataTable ObtenerTabla(string nombreTabla, string consultaSQL)
        {
            DataSet dataSet = new DataSet();

            AccesoConexion datos = new AccesoConexion();

            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdaptador(consultaSQL);

            sqlDataAdapter.Fill(dataSet, nombreTabla);

            return dataSet.Tables[nombreTabla];
        }
        // Obtener todos los productos
        public DataTable ObtenerTodosLosProductos()
        {
            string consultaSQL = "SELECT * FROM Productos";
            return ObtenerTabla("Productos", consultaSQL);
        }

        // Declarar el método ArmarParametrosEliminarProductos
        public void ArmarParametrosEliminarProductos(ref SqlCommand sqlCommand, Producto producto)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter = sqlCommand.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParameter.Value = producto.IdProducto;
        }

        public bool ActualizarProducto(Producto product)
        {
            SqlCommand sqlCommand = new SqlCommand();
            //ArmarParametros
            AccesoConexion acceso = new AccesoConexion();
            int ProductoIn = 1;//EjecutarProcedimiento

            if (ProductoIn == 1) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}