using System;

namespace ENT.SistemaCompraVenta
{
    public class Categoria
    {
        private int idCategoria;
        private string nombre;

        public int ID_Categoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public override string ToString() => nombre;
    }
}
