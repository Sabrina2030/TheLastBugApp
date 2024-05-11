using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.DTOs
{
    public class UsuariosConAyudasDTO
    {
        public string Nombre { get; set; }
        public List<AyudaSocialDTO> AyudasSociales { get; set; }
    }
}
