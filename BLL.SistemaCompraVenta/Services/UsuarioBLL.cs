using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Componentes;

namespace BLL.SistemaCompraVenta.Services
{
    public class UsuarioBLL
    {
        private UsuarioDAL oUsuarioDAL = new UsuarioDAL();
        private RolComposicionBLL oRolComposicionBLL = new RolComposicionBLL();

        public Usuario Login(string dni, string password)
        {
            DataTable tabla = oUsuarioDAL.LoginUsuario(dni, password);
            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            DataRow fila      = tabla.Rows[0];
            int idRol         = Convert.ToInt32(fila["ID_Rol"]);
            string nombreRol  = fila["Rol"].ToString();

            // El rol ES una familia: se arma su árbol Composite (permisos propios +
            // sub-roles en cascada).
            FamiliaPermisos arbol = oRolComposicionBLL.ConstruirArbolDeRol(idRol, nombreRol);

            Usuario usuario = new Usuario
            {
                ID             = Convert.ToInt32(fila["ID"]),
                Nombre         = fila["Nombre"].ToString(),
                Apellido       = fila["Apellido"].ToString(),
                Password       = fila["Password"].ToString(),
                FechaHoraLogin = DateTime.Now,
                Rol            = PermisosFactory.CrearRol(idRol, nombreRol, arbol)
            };

            oUsuarioDAL.RegistrarLogin(usuario.ID, usuario.FechaHoraLogin);
            return usuario;
        }

        public DataTable ObtenerUsuarios()                      => oUsuarioDAL.ObtenerUsuarios();
        public DataTable ObtenerUsuarios(string filtro)         => oUsuarioDAL.ObtenerUsuarios(filtro);
        public DataTable ObtenerRoles()                         => oUsuarioDAL.ObtenerRoles();

        public bool CrearUsuario(string dni, string nombre, string apellido,
                                 string password, int idRol, string email,
                                 DateTime? fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Complete todos los datos obligatorios.");

            int filas = oUsuarioDAL.InsertarUsuario(dni, nombre, apellido,
                                                    password, idRol, email, fechaNacimiento);
            return filas > 0;
        }

        public bool ModificarUsuario(string dni, string nombre, string apellido,
                                     string password, int idRol, string email,
                                     DateTime? fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Complete todos los datos obligatorios.");

            int filas = oUsuarioDAL.ModificarUsuario(dni, nombre, apellido,
                                                     password, idRol, email, fechaNacimiento);
            return filas > 0;
        }

        public bool EliminarUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("DNI inválido.");

            int filas = oUsuarioDAL.EliminarUsuario(dni);
            return filas > 0;
        }
    }
}
