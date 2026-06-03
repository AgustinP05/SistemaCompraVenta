using System;

namespace ENT.SistemaCompraVenta
{

    public abstract class Producto
    {

        private int id;
        private string nombre;
        private double precioVenta;
        private double precioCosto;
        private Stock _stock;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double precioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public double precioCosto
        {
            get { return precioCosto; }
            set { precioCosto = value; }
        }

        public Stock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}