using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_12.Clases;

namespace TP6_Grupo_12.Ejercicio_1
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        GestionProductos gestionProductos = new GestionProductos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarGridView();

                AccesoConexion accesoConexion = new AccesoConexion();
                if (accesoConexion.GenerarProcedimientosAlmacenados())
                {
                    lblMensaje.Text = "Procedimientos almacenados generados correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al generar procedimientos almacenados.";
                }
            }
        }

        /// ELIMINAR
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_idProducto")).Text;

            Producto producto = new Producto(Convert.ToInt32(idProducto));

            GestionProductos gestionProductos = new GestionProductos();

            gestionProductos.EliminarProducto(producto);

            cargarGridView();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        private void cargarGridView()
        {

            GestionProductos gestionProductos = new GestionProductos();

            gvProductos.DataSource = gestionProductos.ObtenerTodosLosProductos();

            gvProductos.DataBind();


        }
    }
}