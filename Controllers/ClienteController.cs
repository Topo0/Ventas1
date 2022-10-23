using apiAlphaVenta.Models;
using apiAlphaVenta.Models.Respuesta;
using apiAlphaVenta.Models.Solicitudes;
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
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito= 0;
            try
            {
                using (DatosVentaContext context = new DatosVentaContext())
                {
                    var list = context.Cliente.OrderByDescending(d => d.IdCliente).ToList();
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

        //metodo agregar
        [HttpPost]
        public IActionResult Add(ClienteRequest rCliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext bDatos = new DatosVentaContext())
                {
                    var nCliente = new Cliente();
                    nCliente.Nombre = rCliente.Nombre;
                    nCliente.Apellido = rCliente.Apellido;
                    bDatos.Cliente.Add(nCliente);
                    bDatos.SaveChanges();
                    respuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //metodo editar
        [HttpPut]
        public IActionResult Edit(ClienteRequest oModels)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext nCli = new DatosVentaContext())
                {
                    Cliente nCliente = nCli.Cliente.Find(oModels.IdCliente);
                    nCliente.Nombre = oModels.Nombre;
                    nCliente.Apellido = oModels.Apellido;
                    nCli.Entry(nCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    nCli.SaveChanges();
                    respuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //metodo eliminar
        [HttpDelete("{IdCliente}")]
        public IActionResult Delete(int IdCliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext ecliente = new DatosVentaContext())
                {
                    Cliente nCliente = ecliente.Cliente.Find(IdCliente);
                    ecliente.Remove(nCliente);
                    ecliente.SaveChanges();
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
