using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Infraestructure.Repository;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;
using GB_Shop.Applications;
using System.Linq;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Route("Reportar")]
        /*
            el siguiente es un json con datos vacios, puede usarse para probar el metodo reportar
            {
                "FechaDenuncia" : "0001-01-01T00:00:00",
                "MotivoDenuncia" : "",
                "DecripLugar" : "",
                "GeoUbi" : "",
                "Colonia" : "",
                "Foto" : ""
            }
        */
        public string reportar(ReporteResponseDto dto)
        {
            var services = new ReporteServices();
            var reporte = services.ResponseToObject(dto);

            var repository = new ReporteSqlRepository();
            var respuesta = repository.reportar(reporte);
            return respuesta;
        }

        [HttpPost]
        [Route("ObtenerTodos")]
        /*
            el siguiente es un json con datos vacios, puede usarse para probar el metodo ObtenerTodos
            {
                "Id" : 0,
                "MotivoDenuncia" : "",
                "GeoUbicacion" : "",
                "Colonia" : ""
            }
        */
        public IActionResult GetByFilter(ReporteFilterDto dto)
        {
            var services = new ReporteServices();
            var reporte = services.DtoToObject(dto);

            var repository = new ReporteSqlRepository();
            var reportes = repository.GetByFilter(reporte);
            var respuesta = reportes.Select(x => services.ObjectToDto(x));

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            if(id == 10)
                return NotFound("No hay nada en esta busqueda");

            if(id == 13)
                return BadRequest("El numero prohibido");

            if(id == 30)
                return Created("Aqui se encuentra lo que buscas: https://www.facebook.com/Mamitas-mens-club-puebla-481841095680477/", 23);

            if(id == 40)
                return NoContent();

            if(id == 50)
               return StatusCode(StatusCodes .Status500InternalServerError, "Todo murio mi chavo");

            if(id == 60)
                return StatusCode(StatusCodes.Status406NotAcceptable, "La neta no se me ocurrio que poner");
            //Cambiar esto
            return Ok(new WeatherForecast{
                Date = DateTime.Now.AddDays(3),
                TemperatureC = id,
                Summary = "Que horror de clima"
            });
        }
    }    
}
