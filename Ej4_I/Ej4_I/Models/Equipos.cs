using System;
using System.Collections.Generic;

namespace Ej4_I.Models
{
    public partial class Equipos
    {
        public Equipos()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int? Facultad { get; set; }

        public virtual Facultad FacultadNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
