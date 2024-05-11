using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Domain.Models
{
    public class AyudaSocial
    {
        public int Id { get; set; }
        public string TipoAyuda { get; set; }
        public int Anio { get; set; }
        public int ComunaId { get; set; }
        public Comuna Comuna { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
