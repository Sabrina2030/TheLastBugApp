using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Domain.Models;

namespace TheLastBug.Business.DTOs
{
    public class AyudaSocialDTO
    {
        public string TipoAyuda { get; set; }
        public int Anio { get; set; }
        public int ComunaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
