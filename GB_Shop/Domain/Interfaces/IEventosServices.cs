using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos;

namespace GB_Shop.Domain.Interfaces
{
    public interface IEventosServices
    {
          public EventosResponseDto ObjectToDto(Eventos Eventos);
        public Eventos ResponseToObject(EventosResponseDto dto);
        public Eventos DtoToObject(EventosFilterDto dto);
        public bool validateEntity(EventosResponseDto Eventos);
    }
}