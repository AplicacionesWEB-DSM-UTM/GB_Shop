using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AutoMapper;
using GB_Shop.Domain.Dtos.Responses;
using GB_Shop.Domain.Entities;
using System;

namespace Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class POIController : ControllerBase
    {
        
        private readonly IPOIRepository _repository;
        private readonly IPOIServices _services;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public POIController(IPOIRepository repository, IPOIServices services, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this._repository = repository;
            this._services = services;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
        }
        
        #region Funciones
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = await _repository.GetById(id);
            var poi = _mapper.Map<Poi, PoiResponse>(query);
            return Ok(poi);

        }

        /*
            link: https://localhost:5001/api/POI/GetByFilter/

            link: https://localhost:5001/api/POI/CountByFilter/

            el siguiente es un json con datos vacios, puede usarse para probar el metodo GetByFilter y CountByFilter
{
    "MotivoDenuncia" : 0,
    "Colonia" : "",
    "FechaDenuncia" : "0001-01-01"
}
        */
        [HttpPost]
        [Route("GetByFilter")]
        public async Task<IActionResult> GetByFilter(PoiFilter dto)
        {
            //var Denuncia = _services.DtoToObject(dto);

            var poi =  _mapper.Map<PoiFilter, Poi>(dto);
            var result =  await _repository.GetByFilter(poi);
            var respuesta = _mapper.Map<IEnumerable<Poi>, IEnumerable<PoiResponse>>(result);
            //var respuesta = Denuncias.Select(x => _services.ObjectToDto(x));

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("CountByFilter")]
        public async Task<IActionResult> CountByFilter(PoiFilter dto)
        {
            //var denuncia = _services.DtoToObject(dto);
            var poi =  _mapper.Map<PoiFilter, Poi>(dto);

            var query = await _repository.CountByFilter(poi);
            return Ok(query);
        }

        /*
            el siguiente es un json con datos vacios, puede usarse para probar el metodo reportar
{
    "MotivoDenuncia":1,
    "DescripcionLugar":"esta horrible",
    "GeoUbicacion":"12.345678903456789, 20,345678234567893",
    "Colonia":"mercedes barrera",
    "Foto":"foto.png"
}
        */
        [HttpPost]
        [Route("")]
        [Route("Crear")]
        public async Task<IActionResult> Crear(PoiResponse dto)
        {
            var validate = _services.validateEntity(dto);

            if(!validate)
            {
                return UnprocessableEntity("El registro no puede ser realizado, debido a que falta información…");
            }
            var id = 0;

            try
            {
                var poi = _services.ResponseToObject(dto);
                id = await _repository.reportar(poi);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            if(id <= 0)
            {
                return Conflict("El registro no puede ser realizado, verifica tu información…");
            }

            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var url_result = $"https://{host}/api/Denuncia/{id}";

            return Created(url_result, id);
        }
    #endregion
    }
}
    
