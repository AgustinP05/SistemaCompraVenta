using System;

namespace ENT.SistemaCompraVenta
{
    public class ProductoVariante
    {
        private int sku;
        private int idProducto;
        private string nombre;
        private string marca;
        private double precioVenta;
        private string color;
        private string talle;
        private int cantidad;

        public int SKU
        {
            get { return sku; }
            set { sku = value; }
        }

        public int ID_Producto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Talle
        {
            get { return talle; }
            set { talle = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public override string ToString()
        {
            return nombre + " | " + color + " | Talle " + talle;
        }
    }
}
