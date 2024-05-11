using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheLastBug.Domain.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Rol { get; set; }
        public List<AyudaSocial> AyudasSociales { get; set; }
        public List<Log> Logs { get; set; }
    }
}
