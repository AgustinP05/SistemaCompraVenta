using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta; // Capa de Entidades
using DAL.SistemaCompraVenta; // Capa de Datos
using BLL.SistemaCompraVenta.Componentes; // Espacio de nombres de la Fábrica del Composite

namespace BLL.SistemaCompraVenta.Services
{
    public class UsuarioBLL
    {
        private UsuarioDAL oUsuarioDAL = new UsuarioDAL(); // Nexo con la capa de datos

        public Usuario Login(string nombre, string password)
        {
            // =================================================================
            // 1. BLOQUES DE PRUEBA (Hardcodeado) - Adaptados al nuevo Composite
            // =================================================================
            if (password == "123")
            {
                if (nombre == "admin" || nombre == "vendedor" || nombre == "gerente" || nombre == "stock")
                {
                    // Convertimos la primera letra en mayúscula para que coincida con la Fábrica
                    string rolSimulado = char.ToUpper(nombre[0]) + nombre.Substring(1);

                    return new Usuario
                    {
                        ID = 999,
                        Nombre = nombre,
                        Password = password,
                        FechaHoraLogin = DateTime.Now,
                        Permisos = PermisosFactory.CrearArbolPermisos(rolSimulado) // Asigna el árbol Composite a Permisos
                    };
                }
            }

            // =================================================================
            // 2. CONEXIÓN REAL CON SQL SERVER (Base de Datos Local)
            // =================================================================
            DataTable tabla = oUsuarioDAL.LoginUsuario(nombre, password);

            // Si las credenciales no existen en tUsuario, el flujo retorna null (Alternativa 1)
            if (tabla == null || tabla.Rows.Count == 0)
            {
                return null;
            }

            // Tomamos el registro encontrado en la primera fila
            DataRow fila = tabla.Rows[0];
            string nombreRolBD = fila["Rol"].ToString();

            // LÓGICA COMPOSITE: Invocamos a la fábrica para armar la estructura jerárquica de permisos
            Componente arbolDePermisos = PermisosFactory.CrearArbolPermisos(nombreRolBD);

            // Mapeamos nuestra entidad de negocio Usuario con la nueva estructura
            Usuario usuario = new Usuario
            {
                ID = Convert.ToInt32(fila["ID"]),
                Nombre = fila["Nombre"].ToString(),
                Password = fila["Password"].ToString(),
                Permisos = arbolDePermisos, // Guardamos toda la estructura Composite con sus permisos
                FechaHoraLogin = DateTime.Now
            };

            // Guardamos en la base de datos la fecha y hora del login (Poscondición en tLogLogin)
            oUsuarioDAL.RegistrarLogin(usuario.ID, usuario.FechaHoraLogin);

            return usuario;
        }

        public DataTable ObtenerUsuarios()
        {
            return oUsuarioDAL.ObtenerUsuarios();
        }
    }
}