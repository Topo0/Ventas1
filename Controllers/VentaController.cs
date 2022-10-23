
using ApiWebClub.Models;
using ApiWebClub.Models.Respuestas;
using ApiWebClub.Models.Solicitudes;
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
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext db = new DatosVentaContext())
                {
                    var venta = new Venta();
                    venta.Total = (decimal)model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                    venta.Fehca = DateTime.Now;
                    venta.IdCliente = model.IdCliente;
                    db.Venta.Add(venta);
                    db.SaveChanges();
                    foreach (var concepto in model.Conceptos)
                    {
                        var vconcepto = new Concepto();
                        vconcepto.Cantidad = concepto.Cantidad;
                        vconcepto.IdProducto = concepto.IdProducto;
                        vconcepto.PrecioUnitario = concepto.PrecioUnitario;
                        vconcepto.IdVenta = venta.IdVenta;
                        db.Concepto.Add(vconcepto);
                        db.SaveChanges();
                    }
                    respuesta.Exito = 1;
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
