using System;

namespace ENT.SistemaCompraVenta
{
    public class Permiso : Componente
    {
        private int idPermiso;

        public int ID_Permiso
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }

        // REQUERIDO: Compara su propio nombre
        public override bool TienePermiso(string nombrePermiso)
        {
            // Me llamo igual al permiso que me estan pidiendo??
            return this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Nombre;
    }
}
