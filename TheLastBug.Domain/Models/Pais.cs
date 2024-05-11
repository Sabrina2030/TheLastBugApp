using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Domain.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Region> Regiones { get; set; }
    }
}
