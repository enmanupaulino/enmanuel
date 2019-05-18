using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Usuario.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string NivelUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string  Clave { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Usuarios(int usuarioId, string nombres, string email, string nivelUsuario, string nombreUsuario, string clave, DateTime fechaIngreso, DateTime fechaRegistro)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            Email = email;
            NivelUsuario = nivelUsuario;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            FechaIngreso = fechaIngreso;
            FechaRegistro = fechaRegistro;
        }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Email = string.Empty;
            NivelUsuario = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            FechaIngreso = DateTime.Now;
            FechaRegistro = DateTime.Now;
        }
    }
    
}
