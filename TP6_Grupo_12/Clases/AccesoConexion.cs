using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;


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
    }
}