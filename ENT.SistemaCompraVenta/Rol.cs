namespace ENT.SistemaCompraVenta
{
    public class Rol
    {
        private int idRol;
        private string nombreRol;

        // Raíz del árbol Composite con los permisos del rol (cargados desde la base).
        private Componente permisos;

        public int ID_Rol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public string NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }

        public Componente Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

        public bool TienePermiso(string nombrePermiso)
        {
            return Permisos != null && Permisos.TienePermiso(nombrePermiso);
        }
    }
}
