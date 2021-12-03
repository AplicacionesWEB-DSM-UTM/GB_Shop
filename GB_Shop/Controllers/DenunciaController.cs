using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AutoMapper;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos.Responses;
using System;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciaRepository _repository;
        private readonly IDenunciaServices _services;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public DenunciaController(IDenunciaRepository repository, IDenunciaServices services, IHttpContextAccessor httpContextAccessor, IMapper mapper)
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
            return Ok(query);

        }

        /*
            link: https://localhost:5001/api/Denuncia/GetByFilter/

            link: https://localhost:5001/api/Denuncia/CountByFilter/

            el siguiente es un json con datos vacios, puede usarse para probar el metodo GetByFilter y CountByFilter
{
    "MotivoDenuncia" : 0,
    "Colonia" : "",
    "FechaDenuncia" : "0001-01-01"
}
        */
        [HttpPost]
        [Route("GetByFilter")]
        public async Task<IActionResult> GetByFilter(DenunciaFilterDto dto)
        {
            var Denuncia = _services.DtoToObject(dto);

            var Denuncias =  await _repository.GetByFilter(Denuncia);
            var respuesta = _mapper.Map<IEnumerable<Denuncia>, IEnumerable<DenunciaResponse>>(Denuncias);
            //var respuesta = Denuncias.Select(x => _services.ObjectToDto(x));

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("CountByFilter")]
        public async Task<IActionResult> CountByFilter(DenunciaFilterDto dto)
        {
            var denuncia = _services.DtoToObject(dto);

            var query = await _repository.CountByFilter(denuncia);
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
        [Route("Denunciar")]
        public async Task<IActionResult> reportar(DenunciaResponseDto dto)
        {
            var validate = _services.validateEntity(dto);

            if(!validate)
            {
                return UnprocessableEntity("El registro no puede ser realizado, debido a que falta información…");
            }
            var id = 0;

            try
            {
                var Foto = _services.ResponseToFoto(dto);
                var IdFoto = _repository.insertFoto(Foto);

                var Denuncia = _services.ResponseToObject(dto, IdFoto);
                id = await _repository.reportar(Denuncia);
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
    }
    #endregion
}