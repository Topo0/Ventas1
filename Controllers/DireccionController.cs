
using ApiWebClub.Models;
using ApiWebClub.Models.Respuestas;
using ApiWebClub.Models.Solicitudes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ApiWebClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
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
                    var lista = context.Direccion.OrderBy(p => p.IdDireccion).ToList();
                    respuesta.Exito = 1;
                    respuesta.Data = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //agregar direccion al cliente 
        [HttpPost]
        public IActionResult Post(DireccionRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext ndireccion = new DatosVentaContext())
                {
                    var direccion = new Direccion();
                    direccion.Calle = model.Calle;
                    direccion.Colonia = model.Colonia;
                    direccion.Numero = model.Numero;
                    direccion.NumeroTelefonico = model.NumeroTelefonico;
                    direccion.Referencias = model.Referencias;
                    ndireccion.Direccion.Add(direccion);
                    ndireccion.SaveChanges();
                    respuesta.Exito = 1;
                }
                

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //editar Direccion
        [HttpPut]
        public IActionResult Edit([FromBody] DireccionRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext edireccion = new DatosVentaContext())
                {
                    var direccion = new Direccion();
                    direccion.Calle = model.Calle;
                    direccion.Colonia = model.Colonia;
                    direccion.Numero = model.Numero;
                    direccion.Referencias = model.Referencias;
                    direccion.NumeroTelefonico = model.NumeroTelefonico;
                    edireccion.Entry(direccion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    edireccion.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //eliminar Dirreccion
        [HttpDelete("{IdProducto}")]
        IActionResult Delete(int IdDireccion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext elDireccion = new DatosVentaContext())
                {
                    var direccion = elDireccion.Direccion.Find(IdDireccion);
                    elDireccion.Remove(direccion);
                    elDireccion.SaveChanges();
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
