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
         public EventosResponseDto ObjectToDto(Eventos Eventos)
        {
           var result = new EventosResponseDto
            (
                IdEvento : Eventos.IdEven, 
                FechaEvento : Eventos.FechaEven,
                HoraEvento : Eventos.HoraEven,
                UbicacionEvento : Eventos.UbicEven,
                GeoUbicacion : Eventos.GeoUbiEve,
                CantPersonas : Eventos.CantPersonas,
                CaracteristicasEvento : Eventos.CaractEven,
                IdPatrocinador: Eventos.IdPatrocinador,
                IdConsideraciones : Eventos.IdConsideraciones
                
            );

            return result;
        }

         public Eventos DtoToObject(EventosFilterDto dto)
        {
            if((dto.IdEven <= 0) && string.IsNullOrEmpty(dto.UbicacionEvento) && string.IsNullOrEmpty(dto.GeoUbicacion) && (dto.CantPersonas <=0) && string.IsNullOrEmpty(dto.CaracteristicasEvento) && (dto.IdPatrocinador <=0) && (dto.IdConsideraciones <=0)  )
            {
                return null;
            }

            var Eventos = new Eventos{
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

                return Eventos;
            }
            public bool validateEntity(EventosResponseDto Eventos)
        {
            if(Eventos.FechaEvento != default (DateTime))
            {
                return false;
            }
            if(Eventos.HoraEvento != default (TimeSpan))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Eventos.UbicacionEvento))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Eventos.GeoUbicacion))
            {
                return false;
            }
            if((Eventos.CantPersonas >0 ))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Eventos.CaracteristicasEvento))
            {
                return false;
            }
            return true;
        }

        public Eventos ResponseToObject(EventosResponseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
