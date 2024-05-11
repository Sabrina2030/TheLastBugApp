using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.DTOs
{
    public class UsuarioDTO
    {
        public int Rol { get; set; }
        public string Nombre { get; set; }  
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
