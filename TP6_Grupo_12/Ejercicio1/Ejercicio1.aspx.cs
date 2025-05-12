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

                AccesoConexion accesoConexion = new AccesoConexion();
                if (accesoConexion.GenerarProcedimientosAlmacenados())
                {
                    lblMensaje.Text = "Procedimientos almacenados generados correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al generar procedimientos almacenados.";
                }

                rellenarProductos();
            }
        }
        protected void rellenarProductos()
        {
            DataTable dt = gestionProductos.ObtenerTodosLosProductos();
            gvProductos.DataSource = dt;
            gvProductos.DataBind();
        }
        /// ELIMINAR
        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_idProducto")).Text;

            Producto product = new Producto(Convert.ToInt32(idProducto));

            GestionProductos gestionProducts = new GestionProductos();
            gestionProducts.EliminarProducto(product);

            rellenarProductos();
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            rellenarProductos();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            rellenarProductos();
        }

        protected void gvProductos_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            // Se obtienen los valores de los controles de la fila editada
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_idProducto")).Text;
            string nombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_nombreProducto")).Text;
            string cantidadPorUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_cantidadPorUnidad")).Text;
            string precioUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_precioUnidad")).Text;

            // Se crea un objeto producto con los datos editados
            Producto product = new Producto(Convert.ToInt32(idProducto), nombreProducto, cantidadPorUnidad, Convert.ToDecimal(precioUnidad));
            // se llama al método ActualizarProducto de la clase GestionProductos
            GestionProductos gestionProducts = new GestionProductos();
            gestionProducts.ActualizarProducto(product);
            // se vuelve a cargar el GridView
            gvProductos.EditIndex = -1;
            rellenarProductos();
        }
    }
}