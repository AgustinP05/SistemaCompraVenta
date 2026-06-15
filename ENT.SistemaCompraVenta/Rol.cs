namespace ENT.SistemaCompraVenta
{
    public class Rol
    {
        public int ID_Rol { get; set; }
        public string NombreRol { get; set; }

        // Raíz del árbol Composite con los permisos del rol (cargados desde la base).
        public Componente Permisos { get; set; }

        public bool TienePermiso(string nombrePermiso)
        {
            return Permisos != null && Permisos.TienePermiso(nombrePermiso);
        }
    }
}
