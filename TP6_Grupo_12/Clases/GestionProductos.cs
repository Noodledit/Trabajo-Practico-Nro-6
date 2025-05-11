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

        public void ArmarParametroProducto(ref SqlCommand comandoSql, Producto producto)
        {// se asigna el valor del idProducto a la variable de la consulta
            comandoSql.Parameters.Add("@IDPRODUCTO", SqlDbType.Int).Value = producto.IdProducto;
            comandoSql.Parameters.Add("@NOMBREPRODUCTO", SqlDbType.NVarChar, 40).Value = producto.NombreProducto;
            comandoSql.Parameters.Add("@CANTIDADPORUNIDAD", SqlDbType.NVarChar, 20).Value = producto.CantidadPorUnidad;
            comandoSql.Parameters.Add("@PRECIOUNIDAD", SqlDbType.Money).Value = producto.PrecioUnidad;
        }

        public bool ActualizarProducto(Producto product)
        {
            SqlCommand comand = new SqlCommand();
            ArmarParametroProducto(ref comand, product);
            AccesoConexion acceso = new AccesoConexion();
            int ProductoIn = acceso.EjecutarProcedimientoAlmacenado(comand, "spActualizarProducto");

            if (ProductoIn == 1) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarProducto(Producto producto)
        {
            SqlCommand sqlCommand = new SqlCommand();

            ArmarParametrosEliminarProductos(ref sqlCommand, producto);

            AccesoConexion accesoConexion = new AccesoConexion();

            int FilasInsertadas = accesoConexion.EjecutarProcedimientoAlmacenado(sqlCommand, "spEliminarProducto");

            if (FilasInsertadas == 1)
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
