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

        // usuario = parte del email anterior al '@' (ej: 'aperea').
        public Usuario Login(string usuario, string password)
        {
            DataTable tabla = oUsuarioDAL.LoginUsuario(usuario);
            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];

            // La contraseña no se almacena: se deriva (ddMM nac. + 4 primeros del DNI) y se compara contra lo ingresado.
            DateTime? fechaNac = fila["FechaNacimiento"] == DBNull.Value
                ? (DateTime?)null
                : Convert.ToDateTime(fila["FechaNacimiento"]);

            string esperada = Credenciales.GenerarPassword(fechaNac, fila["DNI"].ToString());
            if (string.IsNullOrEmpty(esperada) || password != esperada)
                return null;

            int idRol         = Convert.ToInt32(fila["ID_Rol"]);
            string nombreRol  = fila["Rol"].ToString();

            // El rol ES una familia: se arma su árbol Composite (permisos propios +
            // sub-roles en cascada).
            FamiliaPermisos arbol = oRolComposicionBLL.ConstruirArbolDeRol(idRol, nombreRol);

            Usuario usuarioLogueado = new Usuario
            {
                ID              = Convert.ToInt32(fila["ID"]),
                Nombre          = fila["Nombre"].ToString(),
                Apellido        = fila["Apellido"].ToString(),
                DNI             = fila["DNI"].ToString(),
                FechaNacimiento = fechaNac,
                FechaHoraLogin  = DateTime.Now,
                Rol             = PermisosFactory.CrearRol(idRol, nombreRol, arbol)
            };

            oUsuarioDAL.RegistrarLogin(usuarioLogueado.ID, usuarioLogueado.FechaHoraLogin);
            return usuarioLogueado;
        }

        public DataTable ObtenerUsuarios()                      => oUsuarioDAL.ObtenerUsuarios();
        public DataTable ObtenerUsuarios(string filtro)         => oUsuarioDAL.ObtenerUsuarios(filtro);
        public DataTable ObtenerRoles()                         => oUsuarioDAL.ObtenerRoles();
        public DataTable ObtenerVendedores()                    => oUsuarioDAL.ObtenerVendedores();

        // Alta de usuario. La contraseña no se pide (se deriva al loguear) y el email
        // se autogenera. Devuelve el email asignado (null si no se pudo insertar).
        public string CrearUsuario(string dni, string nombre, string apellido,
                                   int idRol, DateTime? fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre)
                || string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Complete todos los datos obligatorios.");
            if (!fechaNacimiento.HasValue)
                throw new Exception("Ingrese la fecha de nacimiento.");

            // El DNI debe tener al menos 4 dígitos: la contraseña usa los 4 primeros.
            if (Credenciales.GenerarPassword(fechaNacimiento, dni) == null)
                throw new Exception("El DNI debe tener al menos 4 dígitos.");

            string email = GenerarEmailUnico(nombre, apellido, null);

            int filas = oUsuarioDAL.InsertarUsuario(dni, nombre, apellido,
                                                    idRol, email, fechaNacimiento);
            return filas > 0 ? email : null;
        }

        // Edición de usuario. Sin contraseña; el email se regenera por si cambió el
        // nombre/apellido (excluyendo al propio usuario). Devuelve el email resultante.
        public string ModificarUsuario(string dni, string nombre, string apellido,
                                       int idRol, DateTime? fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Complete todos los datos obligatorios.");
            if (!fechaNacimiento.HasValue)
                throw new Exception("Ingrese la fecha de nacimiento.");

            string email = GenerarEmailUnico(nombre, apellido, dni);

            int filas = oUsuarioDAL.ModificarUsuario(dni, nombre, apellido,
                                                     idRol, email, fechaNacimiento);
            return filas > 0 ? email : null;
        }

        // Email = inicial del nombre + apellido + @sportupe.com.ar. Si ya existe en
        // otro usuario, le agrega un sufijo numérico (2, 3, ...). dniExcluir ignora al
        // propio usuario (al editar).
        public string GenerarEmailUnico(string nombre, string apellido, string dniExcluir)
        {
            string baseLocal = Credenciales.BaseEmail(nombre, apellido);
            string email = baseLocal + Credenciales.DominioEmail;

            int sufijo = 2;
            while (oUsuarioDAL.ExisteEmail(email, dniExcluir))
            {
                email = baseLocal + sufijo + Credenciales.DominioEmail;
                sufijo++;
            }
            return email;
        }

        public bool EliminarUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("DNI inválido.");

            // La DAL traduce la violación de FK (usuario que tenga operaciones) a una OperacionNoPermitidaException con el mensaje correspondiente.
            return oUsuarioDAL.EliminarUsuario(dni) > 0;
        }
    }
}
