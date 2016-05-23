using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes.Forms.Entities
{
    public class DataMap
    {

        public string Version { get; set; } = "1.0";

        public List<Location> Locations { get; set; } = new List<Location>();

        public class Location
        {
            public string Label { get; set; }
            public string Address { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
    }
}
