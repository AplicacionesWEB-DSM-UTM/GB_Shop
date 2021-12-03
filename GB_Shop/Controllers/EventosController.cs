using System; 
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GB_Shop.Controllers
{
         [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosRepository _repository;
        private readonly IEventosServices _services;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventosController (IEventosRepository repository, IEventosServices services, IHttpContextAccessor httpContextAccessor)
        {
            this._repository = repository;
            this._services = services;
            this._httpContextAccessor = httpContextAccessor;
        }

           [HttpPost]
        [Route("")]
        [Route("Registrar")]
         public async Task<IActionResult> registrar(EventosResponseDto dto)
        {
            var validate = _services.validateEntity(dto);

            if(!validate)
            {
                return UnprocessableEntity("El registro no puede ser realizado, debido a que falta información…");
            }

            var Eventos = _services.ResponseToObject(dto);

            var id =  await _repository.registrar(Eventos);

            

            if(id <= 0)
            {
                return Conflict("El registro no puede ser realizado, verifica tu información…");
            }

            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var url_result = $"https://{host}/api/Eventos/{id}";

            return Created(url_result, id);
        }       
    }
}