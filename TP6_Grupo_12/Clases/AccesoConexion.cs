using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace TP6_Grupo_12.Clases
{
    public class AccesoConexion
    {
        private string stringConnection = "Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno; Integrated Security=True";
   
        public AccesoConexion() { }//constructor

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(stringConnection);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}