
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
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GET()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext context = new DatosVentaContext())
                {
                    var lista = context.Producto.OrderBy(p => p.IdProducto).ToList();
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

        //crear objeto
        [HttpPost]
        public IActionResult Add(ProductoRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using(DatosVentaContext nproducto = new DatosVentaContext())
                {
                    var nuproductos = new Producto();
                    nuproductos.Nombre = model.Nombre;
                    nuproductos.Descripcion = model.Descripcion;
                    nuproductos.Imagen = model.Imagen;
                    nuproductos.Precio = model.Precio;
                    nproducto.Producto.Add(nuproductos);
                    nproducto.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
            
        }

        //editar objeto
        [HttpPut]
        public IActionResult Edit(ProductoRequest model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext eproducto = new DatosVentaContext())
                {
                    var producto = eproducto.Producto.Find(model.IdProducto);
                    producto.Nombre = model.Nombre;
                    producto.Descripcion = model.Descripcion;
                    producto.Imagen = model.Imagen;
                    producto.Precio = model.Precio;
                    eproducto.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    eproducto.SaveChanges();
                    respuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //funcion Eliminar
        [HttpDelete("{IdProducto}")]
        public IActionResult Delete(int IdProducto)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (DatosVentaContext dproducto = new DatosVentaContext())
                {
                    var producto = dproducto.Producto.Find(IdProducto);
                    dproducto.Remove(producto);
                    dproducto.SaveChanges();
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
