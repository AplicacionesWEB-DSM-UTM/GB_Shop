using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Infraestructure.Repository;
using GB_Shop.Domain.Dtos;
using GB_Shop.Applications;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenunciaController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Route("Denunciar")]
        /*
            el siguiente es un json con datos vacios, puede usarse para probar el metodo reportar
            {
                "MotivoDenuncia" : "",
                "DecripLugar" : "",
                "GeoUbi" : "",
                "Colonia" : "",
                "Foto" : ""
            }
        */
        public string reportar(DenunciaResponseDto dto)
        {
            var services = new DenunciaServices();
            var Denuncia = services.ResponseToObject(dto);

            var repository = new DenunciaSqlRepository();
            var respuesta = repository.reportar(Denuncia);
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
        public IActionResult GetByFilter(DenunciaFilterDto dto)
        {
            var services = new DenunciaServices();
            var Denuncia = services.DtoToObject(dto);

            var repository = new DenunciaSqlRepository();
            var Denuncias = repository.GetByFilter(Denuncia);
            var respuesta = Denuncias.Select(x => services.ObjectToDto(x));

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
               return StatusCode(StatusCodes.Status500InternalServerError, "Todo murio mi chavo");

            if(id == 60)
                return StatusCode(StatusCodes.Status406NotAcceptable, "La neta no se me ocurrio que poner");
            //Cambiar esto
            /*return Ok(new WeatherForecast{
                Date = DateTime.Now.AddDays(3),
                TemperatureC = id,
                Summary = "Que horror de clima"
            });*/
            return Ok();
        }
    }
}