using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Domain.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Accion { get; set; }
        public DateTime FechaHora { get; set; }
        public Usuario Usuario { get; set; } 
    }
}
