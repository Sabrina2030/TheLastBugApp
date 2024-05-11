using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Domain.Models
{
    public class Comuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public List<AyudaSocial> AyudasSociales { get; set; }
    }
}
