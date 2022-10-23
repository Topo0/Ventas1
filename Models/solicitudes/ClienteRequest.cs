using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebClub.Models.Solicitudes
{
    public class ClienteRequest
    {

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int IdDireccion { get; set; }
    }
}
