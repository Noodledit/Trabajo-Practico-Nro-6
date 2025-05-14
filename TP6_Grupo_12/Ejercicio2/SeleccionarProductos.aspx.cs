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

        private DataTable CrearTablaSeleccionados()
        {
            DataTable tablaProductos = new DataTable();

            DataColumn dataColumn = new DataColumn("IdProducto", System.Type.GetType("System.Int32"));
            tablaProductos.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NombreProducto", System.Type.GetType("System.String"));
            tablaProductos.Columns.Add(dataColumn);

            dataColumn = new DataColumn("IdProveedor", System.Type.GetType("System.Int32"));
            tablaProductos.Columns.Add(dataColumn);

            dataColumn = new DataColumn("PrecioUnidad", System.Type.GetType("System.Decimal"));
            tablaProductos.Columns.Add(dataColumn);

            return tablaProductos;
        }



        // crear metodo agregar fila
        private void AgregarFila(DataTable tablaProductos, Producto productoSeleccionado)
        {
            DataRow fila = tablaProductos.NewRow();
            fila["IdProducto"] = productoSeleccionado.IdProducto;
            fila["NombreProducto"] = productoSeleccionado.NombreProducto;
            fila["IdProveedor"] = productoSeleccionado.IdProveedor;
            fila["PrecioUnidad"] = productoSeleccionado.PrecioUnidad;
            tablaProductos.Rows.Add(fila);

            Session["tablaProductosSeleccionados"] = tablaProductos;
        }

        private bool ptoExtraConsultarID(DataTable tablaProductosSeleccionados, Producto productoSeleccionado)
        {
            foreach (DataRow fila in tablaProductosSeleccionados.Rows)
            {
                if ((int)fila["IdProducto"] == productoSeleccionado.IdProducto)
                {
                    lblAgregadoCorrectamente.Text = "El producto ya fue agregado";
                    return true;
                }
                lblAgregadoCorrectamente.Text = "";
            }
            return false;
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
                if (!ptoExtraConsultarID((DataTable)Session["tablaProductosSeleccionados"], productoSeleccionado))
                {
                    AgregarFila((DataTable)Session["tablaProductosSeleccionados"], productoSeleccionado);
                }
                else
                {
                    lblAvisoAgregado.Text = "El producto ya fue agregado";
                }
            }
            lblAvisoAgregado.Text = productoSeleccionado.NombreProducto;
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            LLenarTablaProductos();
        }
    }
}