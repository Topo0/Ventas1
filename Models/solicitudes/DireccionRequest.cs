using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebClub.Models.Solicitudes
{
    public class DireccionRequest
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int? Numero { get; set; }
        public string NumeroTelefonico { get; set; }
        public string Referencias { get; set; }


       
    }
}
