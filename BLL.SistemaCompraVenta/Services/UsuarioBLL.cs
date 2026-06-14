using System;
using System.Data;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Componentes;

namespace BLL.SistemaCompraVenta.Services
{
    public class UsuarioBLL
    {
        private UsuarioDAL oUsuarioDAL = new UsuarioDAL();

        public Usuario Login(string dni, string password)
        {
            // Bloque de prueba (credenciales hardcodeadas)
            if (password == "123")
            {
                if (dni == "admin" || dni == "vendedor" || dni == "gerente" || dni == "stock")
                {
                    string rolSimulado = char.ToUpper(dni[0]) + dni.Substring(1);
                    return new Usuario
                    {
                        ID             = 999,
                        Nombre         = dni,
                        Password       = password,
                        FechaHoraLogin = DateTime.Now,
                        Permisos       = PermisosFactory.CrearArbolPermisos(rolSimulado)
                    };
                }
            }

            DataTable tabla = oUsuarioDAL.LoginUsuario(dni, password);
            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            DataRow fila           = tabla.Rows[0];
            string nombreRolBD     = fila["Rol"].ToString();
            Componente arbolPermisos = PermisosFactory.CrearArbolPermisos(nombreRolBD);

            Usuario usuario = new Usuario
            {
                ID             = Convert.ToInt32(fila["ID"]),
                ID_Rol         = Convert.ToInt32(fila["ID_Rol"]),
                Nombre         = fila["Nombre"].ToString(),
                Password       = fila["Password"].ToString(),
                Permisos       = arbolPermisos,
                FechaHoraLogin = DateTime.Now
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
