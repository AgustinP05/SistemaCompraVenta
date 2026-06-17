using System;

namespace ENT.SistemaCompraVenta
{
    public class Permiso : Componente
    {
        public int ID_Permiso { get; set; }

        // REQUERIDO: Compara su propio nombre
        public override bool TienePermiso(string nombrePermiso)
        {
            // Me llamo igual al permiso que me estan pidiendo??
            return this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => Nombre;
    }
}


