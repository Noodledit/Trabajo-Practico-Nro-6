using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_12.Clases;

namespace TP6_Grupo_12.Ejercicio2
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                LLenarTablaProductosSeleccionados();
            }
        }
        // crear metodo agregar fila que agregue una fila a la tabla de productos seleccionados
        protected void LLenarTablaProductosSeleccionados()
        {
            if (Session["tablaProductosSeleccionados"] != null)
            {
                gvProductosSeleccionados.DataSource = (DataTable)Session["tablaProductosSeleccionados"];
                gvProductosSeleccionados.DataBind();
            }
        }

    }
}