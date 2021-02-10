using System;
using System.Collections.Generic;

namespace Ej3_GA.Models
{
    public partial class MaquinasRegistradoras
    {
        public MaquinasRegistradoras()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public int? Piso { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
