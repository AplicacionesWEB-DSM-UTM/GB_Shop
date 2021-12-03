using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Dtos.Responses;

namespace GB_Shop.Domain.Interfaces
{
    public interface IPOIServices
    {
       public POIResponseDto ObjectToDto(Poi Poi);
        public Poi ResponseToObject(PoiResponse dto);
        public Poi DtoToObject(POIFilterDto dto);
        public bool validateEntity(PoiResponse Poi);
    }
}