using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciaRepository _repository;
        private readonly IDenunciaServices _services;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DenunciaController(IDenunciaRepository repository, IDenunciaServices services, IHttpContextAccessor httpContextAccessor)
        {
            this._repository = repository;
            this._services = services;
            this._httpContextAccessor = httpContextAccessor;
        }
        
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
        public async Task<IActionResult> reportar(DenunciaResponseDto dto)
        {
            var validate = _services.validateEntity(dto);

            if(!validate)
            {
                UnprocessableEntity("El registro no puede ser realizado, debido a que falta información…");
            }

            var Denuncia = _services.ResponseToObject(dto);

            var id =  await _repository.reportar(Denuncia);

            if(id <= 0)
            {
                return Conflict("El registro no puede ser realizado, verifica tu información…");
            }

            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var url_result = $"https://{host}/api/Denuncia/{id}";

            return Created(url_result, id);
        }

        [HttpPost]
        [Route("ObtenerTodos")]
        /*
            link: https://localhost:5001/api/Denuncia/ObtenerTodos/

            el siguiente es un json con datos vacios, puede usarse para probar el metodo ObtenerTodos
            {
                "Id" : 0,
                "MotivoDenuncia" : "",
                "GeoUbicacion" : "",
                "Colonia" : ""
            }
        */
        public async Task<IActionResult> GetByFilter(DenunciaFilterDto dto)
        {
            var Denuncia = _services.DtoToObject(dto);

            var Denuncias =  await _repository.GetByFilter(Denuncia);
            var respuesta = Denuncias.Select(x => _services.ObjectToDto(x));

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