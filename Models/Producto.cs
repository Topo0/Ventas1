using System;
using System.Collections.Generic;

namespace ApiWebClub.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Concepto = new HashSet<Concepto>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
