using System;
using System.Collections.Generic;

namespace ApiWebClub.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Concepto = new HashSet<Concepto>();
        }

        public int IdVenta { get; set; }
        public DateTime? Fehca { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
