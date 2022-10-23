using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebClub.Models.Solicitudes
{
    public class VentaRequest
    {
        public int? IdCliente { get; set; }
        public decimal Total { get; set; }

        public List<ConceptoRequests> Conceptos { get; set; }

        public VentaRequest()
        {
            this.Conceptos = new List<ConceptoRequests>();
        }

    }

    public class ConceptoRequests
    {
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
}
