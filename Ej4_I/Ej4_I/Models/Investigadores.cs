using System;
using System.Collections.Generic;

namespace Ej4_I.Models
{
    public partial class Investigadores
    {
        public Investigadores()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string Dni { get; set; }
        public string NomApels { get; set; }
        public int? Facultad { get; set; }

        public virtual Facultad FacultadNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
