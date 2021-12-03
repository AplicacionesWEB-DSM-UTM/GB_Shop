using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos;

namespace GB_Shop.Domain.Interfaces
{
    public interface IEventosServices
    {
          public EventosResponseDto ObjectToDto(Evento Evento);
        public Evento ResponseToObject(EventosResponseDto dto);
        public Evento DtoToObject(EventosFilterDto dto);
        public bool validateEntity(EventosResponseDto Evento);
    }
}