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

        protected void CrearTablaSeleccionados()
        {
            // Crear la nueva tabla para los productos seleccionados
            DataTable SelectedProductsTable = new DataTable();

            // Definir las columnas
            SelectedProductsTable.Columns.Add("ID", typeof(int));
            SelectedProductsTable.Columns.Add("Nombre", typeof(string));
            SelectedProductsTable.Columns.Add("Precio", typeof(decimal));

            // Recorrer los productos en gvProductos
            foreach (GridViewRow row in gvProductos.Rows)
            {
                CheckBox chkSeleccionado = row.FindControl("chkSeleccionado") as CheckBox;
                if (chkSeleccionado != null && chkSeleccionado.Checked)
                {
                    // Agregar el producto seleccionado a la tabla
                    DataRow dr = SelectedProductsTable.NewRow();
                    dr["ID"] = Convert.ToInt32(gvProductos.DataKeys[row.RowIndex].Value);
                    dr["Nombre"] = row.Cells[1].Text;
                    dr["Precio"] = Convert.ToDecimal(row.Cells[2].Text);

                    SelectedProductsTable.Rows.Add(dr);
                }
            }

            // Guardar la tabla en una variable Session
            Session["SelectedProducts"] = SelectedProductsTable;

            // Enlazar la tabla al GridView gvSeleccionados
            gvSeleccionados.DataSource = SelectedProductsTable;
            gvSeleccionados.DataBind();
        }



    }
}