using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class FamiliaBLL
    {
        private FamiliaDAL oFamiliaDAL = new FamiliaDAL();

        public List<FamiliaPermisos> ListarTodas() => oFamiliaDAL.ListarTodas();

        public List<FamiliaPermisos> ListarPorRol(int idRol) => oFamiliaDAL.ListarPorRol(idRol);

        // Permisos (hojas) que contiene una familia.
        public List<Permiso> PermisosDeFamilia(int idFamilia) => oFamiliaDAL.PermisosDeFamilia(idFamilia);

        // Familias otorgadas a un rol, cada una con sus permisos (hojas) cargados.
        // Es lo que se enchufa al árbol Composite al loguear.
        public List<FamiliaPermisos> ConstruirFamiliasDeRol(int idRol)
        {
            List<FamiliaPermisos> familias = oFamiliaDAL.ListarPorRol(idRol);
            foreach (FamiliaPermisos familia in familias)
                foreach (Permiso permiso in oFamiliaDAL.PermisosDeFamilia(familia.ID_Familia))
                    familia.AgregarHijo(permiso);
            return familias;
        }

        // Resincroniza las familias del rol: borra las actuales y asigna las recibidas.
        public void GuardarFamiliasDeRol(int idRol, List<FamiliaPermisos> familias)
        {
            oFamiliaDAL.QuitarTodasDeRol(idRol);
            foreach (FamiliaPermisos familia in familias)
                oFamiliaDAL.AsignarARol(idRol, familia.ID_Familia);
        }
    }
}
