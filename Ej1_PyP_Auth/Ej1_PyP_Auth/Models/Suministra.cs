using System;
using System.Collections.Generic;

namespace Ej1_PyP_Auth.Models
{
    public partial class Suministra
    {
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int? Precio { get; set; }

        public virtual Piezas CodigoPiezaNavigation { get; set; }
        public virtual Proveedores IdProveedorNavigation { get; set; }
    }
}
