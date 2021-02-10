using System;
using System.Collections.Generic;

namespace Ej3_GA.Models
{
    public partial class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public virtual Cajeros CajeroNavigation { get; set; }
        public virtual MaquinasRegistradoras MaquinaNavigation { get; set; }
        public virtual Productos ProductoNavigation { get; set; }
    }
}
