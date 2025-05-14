using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_12.Clases;

namespace TP6_Grupo_12.Ejercicio_2
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnEliminarProductoSeleccionado_Click(object sender, EventArgs e)
        {
            Session["tablaProductosSeleccionados"] = null;
            lblMensajeEliminar.Text = "Los productos fueron eliminados";
        }

    }
}