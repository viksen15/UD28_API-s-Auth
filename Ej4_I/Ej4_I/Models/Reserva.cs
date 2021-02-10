using System;
using System.Collections.Generic;

namespace Ej4_I.Models
{
    public partial class Reserva
    {
        public string Dni { get; set; }
        public string NumSerie { get; set; }
        public DateTime? Comienzo { get; set; }
        public DateTime? Fin { get; set; }

        public virtual Investigadores DniNavigation { get; set; }
        public virtual Equipos NumSerieNavigation { get; set; }
    }
}
