using System;

namespace ENT.SistemaCompraVenta
{
    public class Permiso : Componente
    {
        public override string Mostrar()
        {
            return "- " + Nombre + Environment.NewLine;
        }

        // REQUERIDO: Compara su propio nombre
        public override bool TienePermiso(string nombrePermiso)
        {
            return this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }
    }
}


