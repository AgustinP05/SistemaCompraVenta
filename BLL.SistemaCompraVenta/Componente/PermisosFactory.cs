using System;
using ENT.SistemaCompraVenta; // Para reconocer Componente, Permiso y FamiliaPermisos

namespace BLL.SistemaCompraVenta.Componentes
{
    public static class PermisosFactory
    {//Factory: Centraliza la logica de creacion para que no haya duplicacion de codigo cada vez que instanciamos un usuario nuevo.
        public static Componente CrearArbolPermisos(string nombreRol)
        {
            // Crea la raíz del Composite (el grupo/rol que contiene a los demás)
            FamiliaPermisos rolComposite = new FamiliaPermisos { Nombre = nombreRol };

            // Instancia los permisos atómicos (Hojas) tal cual los usa el swich
            Permiso login = new Permiso { Nombre = "LogIn" };
            Permiso gestionarUsuarios = new Permiso { Nombre = "GestionarUsuarios" };
            Permiso registrarVentas = new Permiso { Nombre = "RegistrarVentas" };
            Permiso verReportes = new Permiso { Nombre = "VerReportes" };
            Permiso gestionarProductos = new Permiso { Nombre = "GestionarProductos" };

            // Rol de la base de datos
            switch (nombreRol)
            {
                case "Administrador":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(gestionarUsuarios);
                    rolComposite.AgregarHijo(registrarVentas);
                    rolComposite.AgregarHijo(verReportes);
                    rolComposite.AgregarHijo(gestionarProductos);
                    break;

                case "Vendedor":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(registrarVentas);
                    break;

                case "Gerente":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(verReportes);
                    break;

                case "Stock":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(gestionarProductos);
                    break;
           
                 case "SuperGerente":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(verReportes);
                    rolComposite.AgregarHijo(gestionarUsuarios);
                break;
            }
            return rolComposite;
        }
    }
}