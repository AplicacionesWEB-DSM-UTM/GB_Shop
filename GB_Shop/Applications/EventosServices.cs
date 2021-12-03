using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Interfaces;
namespace GB_Shop.Applications
{
    public class EventosServices : IEventosServices
    {
         public EventosResponseDto ObjectToDto(Evento Evento)
        {
           var result = new EventosResponseDto
            (
                IdEvento : Evento.IdEven, 
                FechaEvento : Evento.FechaEven,
                HoraEvento : Evento.HoraEven,
                UbicacionEvento : Evento.UbicEven,
                GeoUbicacion : Evento.GeoUbiEve,
                CantPersonas : Evento.CantPersonas,
                CaracteristicasEvento : Evento.CaractEven,
                IdPatrocinador: Evento.IdPatrocinador,
                IdConsideraciones : Evento.IdConsideraciones
                
            );

            return result;
        }

         public Evento DtoToObject(EventosFilterDto dto)
        {
            if((dto.IdEven <= 0) && string.IsNullOrEmpty(dto.UbicacionEvento) && string.IsNullOrEmpty(dto.GeoUbicacion) && (dto.CantPersonas <=0) && string.IsNullOrEmpty(dto.CaracteristicasEvento) && (dto.IdPatrocinador <=0) && (dto.IdConsideraciones <=0)  )
            {
                return null;
            }

            var Evento = new Evento{
                IdEven = dto.IdEven,
                FechaEven = default(DateTime),
                HoraEven = default,
                UbicEven = dto.UbicacionEvento,
                GeoUbiEve = dto.GeoUbicacion,
                CantPersonas = dto.CantPersonas,
                CaractEven = dto.CaracteristicasEvento,
                IdPatrocinador = dto.IdPatrocinador,
                IdConsideraciones = dto.IdConsideraciones


                };

                return Evento;
            }
            public bool validateEntity(EventosResponseDto Evento)
        {
            if(Evento.FechaEvento != default (DateTime))
            {
                return false;
            }
            if(Evento.HoraEvento != default (TimeSpan))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Evento.UbicacionEvento))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Evento.GeoUbicacion))
            {
                return false;
            }
            if((Evento.CantPersonas >0 ))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Evento.CaracteristicasEvento))
            {
                return false;
            }
            return true;
        }

        public Evento ResponseToObject(EventosResponseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}