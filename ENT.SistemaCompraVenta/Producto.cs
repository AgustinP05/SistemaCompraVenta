using System;

namespace ENT.SistemaCompraVenta
{

    public abstract class Producto
    {

        private int id;
        private string nombre;
        private string marca;
        private int idCategoria;
        private string categoria;
        private double precioVenta;
        private double precioCosto;


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

        public int ID_Categoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
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
    }
}
