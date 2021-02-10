using System;
using System.Collections.Generic;

namespace Ej2_C_Auth.Models
{
    public partial class Cientificos
    {
        public Cientificos()
        {
            AsignadoA = new HashSet<AsignadoA>();
        }

        public string Dni { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<AsignadoA> AsignadoA { get; set; }
    }
}
