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
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Poi = await _repository.GetById(id);

            if(Poi == null)
                return NotFound($"No fue posible encontrar resultados con el id {id}...");

            var respuesta = _mapper.Map<Poi, PoiResponse>(Poi);
            return Ok(respuesta);
        }

        
        
    }

}
    
