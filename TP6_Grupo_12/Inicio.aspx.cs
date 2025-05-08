using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_Grupo_12
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnEjercicio1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio 1/Ejercicio1.aspx");
        }

        protected void lbtnEjercicio2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio 2/Ejercicio2.aspx");
        }
    }
}