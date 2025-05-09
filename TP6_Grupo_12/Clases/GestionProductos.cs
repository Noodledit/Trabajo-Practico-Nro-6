using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

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
        // Declarar el método ArmarParametrosEliminarProductos
        private void ArmarParametrosEliminarProductos(ref SqlCommand sqlCommand, Libro libro)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter = sqlCommand.Parameters.Add("@IdLibro", SqlDbType.Int);
            sqlParameter.Value = libro.IdLibro;
        }
 


    }
}