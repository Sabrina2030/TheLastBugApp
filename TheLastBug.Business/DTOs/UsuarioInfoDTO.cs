using System;
using System.Collections.Generic;
using System.Text;

namespace TheLastBug.Business.DTOs
{
    public class UsuarioInfoDTO
    {
        public int Id { get; set; } 
        public int IsAdmin { get; set; }
        public string UserName { get; set; }
    }
}
