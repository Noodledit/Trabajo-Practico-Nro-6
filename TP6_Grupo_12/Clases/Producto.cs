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
        private int _IdProveedor;
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

        //GETTERS y SETTERS
        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
        }

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }

        public string CantidadPorUnidad
        {
            get { return _CantidadPorUnidad; }
            set { _CantidadPorUnidad = value; }
        }

        public decimal PrecioUnidad
        {
            get { return _PrecioUnidad; }
            set { _PrecioUnidad = value; }
        }


    }
}