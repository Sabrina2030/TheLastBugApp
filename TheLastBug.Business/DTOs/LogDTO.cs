using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.DTOs
{
    public class LogDTO
    {
        public int UserId { get; set; }
        public string Accion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
