using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Data.Common;


namespace TP6_Grupo_12.Clases
{
    public class AccesoConexion
    {
        private string stringConnection = "Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno; Integrated Security=True;";

        public AccesoConexion() { }//constructor

        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(stringConnection);
                conexion.Open();
                return conexion;
            }
            catch (Exception exception)
            {
                try
                {
                    string stringSecundaryConnection = stringConnection.Replace("\\sqlexpress", "");
                    SqlConnection conexion = new SqlConnection(stringSecundaryConnection);
                    conexion.Open();
                    return conexion;
                }
                catch (Exception exception2)
                {
                    return null;
                }
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consulta)
        {

            SqlDataAdapter adaptadorSQL;

            try
            {
                adaptadorSQL = new SqlDataAdapter(consulta, ObtenerConexion());
                return adaptadorSQL;

            }
            catch (Exception exception)
            {
                {
                    return null;
                }
            }

        }
        public bool GenerarProcedimientosAlmacenados()
        {
            bool estado = false;
            string agregarProcedimientoActualizar =
                "IF OBJECT_ID('dbo.spActualizarProducto', 'P') IS NULL " +
                "BEGIN " +
                "EXEC('CREATE PROCEDURE [dbo].[spActualizarProducto] " +
                "(@IDPRODUCTO INT, @NOMBREPRODUCTO NVARCHAR(40), @CANTIDADPORUNIDAD NVARCHAR(20), @PRECIOUNIDAD MONEY) " +
                "AS BEGIN " +
                "UPDATE Productos SET " +
                "NombreProducto = @NOMBREPRODUCTO, " +
                "CantidadPorUnidad = @CANTIDADPORUNIDAD, " +
                "PrecioUnidad = @PRECIOUNIDAD " +
                "WHERE IDProducto = @IDPRODUCTO; " +
                "END') " +
                "END";

            string agregarProcedimientoEliminar =
                "IF OBJECT_ID('dbo.spEliminarProducto', 'P') IS NULL " +
                "BEGIN " +
                "EXEC('CREATE PROCEDURE [dbo].[spEliminarProducto] " +
                "(@IDPRODUCTO INT) " +
                "AS BEGIN " +
                "DELETE FROM Productos WHERE IDProducto = @IDPRODUCTO; " +
                "END') " +
                "END";

            using (SqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(agregarProcedimientoActualizar, conexion);
                    
                        sqlCommand.ExecuteNonQuery();

                    sqlCommand = new SqlCommand(agregarProcedimientoEliminar, conexion);
                    
                        sqlCommand.ExecuteNonQuery();
                    
                    estado = true;
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    estado = false;
                    // Puedes registrar el error aquí si lo necesitas
                }
            }
            return estado;
        }

    }
}