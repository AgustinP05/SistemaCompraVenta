using System;

namespace ENT.SistemaCompraVenta
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string password;
        private string dni;
        private DateTime fechaHoraLogin;
        private string apellido;
        private string email;
        private DateTime? fechaNacimiento;
        private Rol rol;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public DateTime FechaHoraLogin
        {
            get { return fechaHoraLogin; }
            set { fechaHoraLogin = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime? FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Rol Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public string NombreMostrar => $"{$"{Nombre} {Apellido}".Trim()} ({Rol?.NombreRol})";
    }
}
