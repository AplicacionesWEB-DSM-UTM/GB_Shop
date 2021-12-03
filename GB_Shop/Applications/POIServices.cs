using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Dtos.Responses;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Interfaces;

namespace GB_Shop.Applications
{
    public class POIServices : IPOIServices
    {
        public POIResponseDto ObjectToDto(Poi Poi)
        {
            return new POIResponseDto
            (
                IdMotivo : Poi.IdMotivo,
                Confirmaciones : Poi.Confirmar,
                Rechazar : Poi.Rechazar,
                GeoUbicacion : Poi.GeoUbiDen,
                Colonia : Poi.Colonia
            );
        }

        public Poi ResponseToObject(PoiResponse dto)
        {
            if(!validateEntity(dto))
            {
                return null;
            }
            
            var Poi = new Poi{
                Confirmar = dto.Confirmaciones,
                Rechazar = dto.Rechazar,
                GeoUbiDen = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                IdMotivo = dto.IdMotivo,
            };

            return Poi;
        }

        public Poi DtoToObject(POIFilterDto dto)
        {
            if((dto.IdMotivo <= 0) && string.IsNullOrEmpty(dto.Colonia) && (dto.Rechazar <= 0) && (dto.Confirmaciones <= 0) && string.IsNullOrEmpty(dto.GeoUbicacion))
            {
                return null;
            }

            var Poi = new Poi{
                Confirmar = dto.Confirmaciones,
                Rechazar = dto.Rechazar,
                GeoUbiDen = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                IdMotivo = dto.IdMotivo,
            };

            return Poi;
        }

        public bool validateEntity(PoiResponse Poi)
        {
            if(Poi.IdMotivo<= 0)
            {
                return false;
            }
            if(string.IsNullOrEmpty(Poi.GeoUbicacion))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Poi.Colonia))
            {
                return false;
            }
            if(Poi.Confirmaciones <= 0)
            {
                return false;
            }
            if(Poi.Rechazar <= 0)
            {
                return false;
            }
            return true;
        }
    }
}