using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Domain.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public List<Comuna> Comunas { get; set; }
    }
}
