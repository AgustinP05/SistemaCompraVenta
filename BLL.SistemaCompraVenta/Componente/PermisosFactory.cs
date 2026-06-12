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
            Permiso gestionarClientes = new Permiso { Nombre = "GestionarClientes" };
            Permiso gestionarProveedores = new Permiso { Nombre = "GestionarProveedores" };


            // Sub-árboles reutilizables por rol
            FamiliaPermisos rolVendedor = new FamiliaPermisos { Nombre = "Vendedor" };
            rolVendedor.AgregarHijo(login);
            rolVendedor.AgregarHijo(registrarVentas);
            rolVendedor.AgregarHijo(gestionarClientes);

            FamiliaPermisos rolGerente = new FamiliaPermisos { Nombre = "Gerente" };
            rolGerente.AgregarHijo(login);
            rolGerente.AgregarHijo(verReportes);

            FamiliaPermisos rolStock = new FamiliaPermisos { Nombre = "Stock" };
            rolStock.AgregarHijo(login);
            rolStock.AgregarHijo(gestionarProductos);
            rolStock.AgregarHijo(gestionarProveedores);

            FamiliaPermisos rolSuperGerente = new FamiliaPermisos { Nombre = "SuperGerente" };
            rolSuperGerente.AgregarHijo(login);
            rolSuperGerente.AgregarHijo(verReportes);
            rolSuperGerente.AgregarHijo(gestionarUsuarios);


            // Rol de la base de datos
            switch (nombreRol)
            {
                case "Administrador":
                    rolComposite.AgregarHijo(rolVendedor);
                    rolComposite.AgregarHijo(rolGerente);
                    rolComposite.AgregarHijo(rolStock);
                    rolComposite.AgregarHijo(rolSuperGerente);
     
                    break;

                case "Vendedor":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(registrarVentas);
                    rolComposite.AgregarHijo(gestionarClientes);

                    break;

                case "Gerente":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(verReportes);
                    break;

                case "Stock":
                    rolComposite.AgregarHijo(login);
                    rolComposite.AgregarHijo(gestionarProductos);
                    rolComposite.AgregarHijo(gestionarProveedores);
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


