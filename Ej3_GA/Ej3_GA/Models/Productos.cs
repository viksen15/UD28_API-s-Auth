using System;
using System.Collections.Generic;

namespace Ej3_GA.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Precio { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
