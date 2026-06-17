using ENT.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta.Componentes
{
    public static class PermisosFactory
    {
        // Cada rol ES una familia de permisos. El árbol (con permisos propios y
        // sub-roles en cascada) ya viene armado por RolComposicionBLL; acá solo se
        // envuelve en la entidad Rol.
        public static Rol CrearRol(int idRol, string nombreRol, Componente arbolPermisos)
        {
            return new Rol
            {
                ID_Rol = idRol,
                NombreRol = nombreRol,
                Permisos = arbolPermisos
            };
        }
    }
}
