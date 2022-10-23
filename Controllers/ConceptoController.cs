
using ApiWebClub.Models;
using ApiWebClub.Models.Respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext context = new DatosVentaContext())
                {
                    var list =context.Venta.OrderByDescending(d => d.IdVenta).ToList();
                    respuesta.Exito = 1;
                    respuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        
    }

    
}
