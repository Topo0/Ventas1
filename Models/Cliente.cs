using System;
using System.Collections.Generic;

namespace ApiWebClub.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdDireccion { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
