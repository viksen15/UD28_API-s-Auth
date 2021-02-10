using System;
using System.Collections.Generic;

namespace Ej2_C_Auth.Models
{
    public partial class AsignadoA
    {
        public string Cientifico { get; set; }
        public string Proyecto { get; set; }

        public virtual Cientificos CientificoNavigation { get; set; }
        public virtual Proyecto ProyectoNavigation { get; set; }
    }
}
