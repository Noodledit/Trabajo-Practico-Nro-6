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
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             LLenarTablaProductos();
            }

        }

        protected void LLenarTablaProductos()
        {
            GestionProductos ProductManagement = new GestionProductos();
            DataTable ProductTable = ProductManagement.ObtenerTodosLosProductos();
            gvProductos.DataSource = ProductTable; 
            gvProductos.DataBind();
        }

        protected DataTable CrearTablaSeleccionados()
        {

        }

        protected DataTable AgregarFila(DataTable TablaSeleccionados, Producto productoSeleccionado)
        {

        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Producto productoSeleccionado = new Producto();

            productoSeleccionado.IdProducto = Convert.ToInt32(((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_idProducto")).Text);
            productoSeleccionado.NombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_nombreProducto")).Text;
            productoSeleccionado.IdProveedor = Convert.ToInt32(((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_idProveedor")).Text);
            productoSeleccionado.PrecioUnidad = Convert.ToDecimal(((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_precioUnitario")).Text);

            if (Session["tablaProductosSeleccionados"] == null)
            {
                Session["tablaProductosSeleccionados"] = CrearTablaSeleccionados();

                AgregarFila((DataTable)Session["tablaProductosSeleccionados"], productoSeleccionado);
            }
            else
            {
                AgregarFila((DataTable)Session["tablaProductosSeleccionados"], productoSeleccionado);
            }

            lblAvisoAgregado.Text = productoSeleccionado.NombreProducto;
        }
    }
}