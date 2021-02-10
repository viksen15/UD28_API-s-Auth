using System;
using System.Collections.Generic;

namespace Ej2_C_Auth.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            AsignadoA = new HashSet<AsignadoA>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public int? Horas { get; set; }

        public virtual ICollection<AsignadoA> AsignadoA { get; set; }
    }
}
