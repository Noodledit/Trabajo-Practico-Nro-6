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

        private DataTable ObtenerTabla(string nombreTabla, string consultaSQL)
        {

            DataSet dataSet = new DataSet();

            AccesoConexion datos = new AccesoConexion();

            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdaptador(consultaSQL);

            sqlDataAdapter.Fill(dataSet, nombreTabla);

            return dataSet.Tables[nombreTabla];

        }



    }
}