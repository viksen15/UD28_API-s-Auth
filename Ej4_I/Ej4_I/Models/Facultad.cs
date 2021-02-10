using System;
using System.Collections.Generic;

namespace Ej4_I.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Equipos = new HashSet<Equipos>();
            Investigadores = new HashSet<Investigadores>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<Investigadores> Investigadores { get; set; }
    }
}
