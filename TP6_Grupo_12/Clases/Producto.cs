using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Grupo_12.Clases
{
    public class Producto
    {
        private int _IdProducto;
        private string _NombreProducto;
        private string _CantidadPorUnidad;
        private decimal _PrecioUnidad;
        public Producto() { }

        public Producto(int idProducto) 
        {
            _IdProducto = idProducto;
        }

        public Producto(int idProducto, string nombreProducto, string cantidadPorUnidad, decimal precioUnitario)
        {
            _IdProducto = idProducto;
            _NombreProducto = nombreProducto;
            _CantidadPorUnidad = cantidadPorUnidad;
            _PrecioUnidad = precioUnitario;
        }
    }
}