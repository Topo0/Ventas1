using System;
using System.Collections.Generic;

namespace ApiWebClub.Models
{
    public partial class Usuario
    {
        public int IdUser { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
    }
}
