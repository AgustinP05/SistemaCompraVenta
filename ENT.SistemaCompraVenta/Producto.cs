using System;

namespace ENT.SistemaCompraVenta
{

    public abstract class Producto
    {

        private int id;
        private string nombre;
        private string marca;
        private string color;
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

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public double PrecioCosto
        {
            get { return precioCosto; }
            set { precioCosto = value; }
        }

        public Stock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        // Propiedad "Puente" para que la grilla vea el número y no el objeto
        public int CantidadStock
        {
            get { return Stock != null ? Stock.Cantidad : 0; }
            set
            {
                if (Stock == null) Stock = new Stock();
                Stock.Cantidad = value;
            }
        }
        public abstract string DevolverTalle();

    }
}