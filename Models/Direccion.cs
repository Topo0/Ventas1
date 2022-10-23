using System;
using System.Collections.Generic;

namespace ApiWebClub.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int? Numero { get; set; }
        public string NumeroTelefonico { get; set; }
        public string Referencias { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
