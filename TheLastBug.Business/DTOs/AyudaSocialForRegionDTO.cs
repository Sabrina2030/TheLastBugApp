using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.DTOs
{
    public class AyudaSocialForRegionDTO
    {
        public string TipoAyuda { get; set; }
        public int Anio { get; set; }
        public int RegionId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
