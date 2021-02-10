using System;
using System.Collections.Generic;

namespace Ej1_PyP_Auth.Models
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            Suministra = new HashSet<Suministra>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministra { get; set; }
    }
}
