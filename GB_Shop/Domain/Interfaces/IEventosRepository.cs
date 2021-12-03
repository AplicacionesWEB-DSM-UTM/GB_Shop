using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Domain.Interfaces
{
    public interface IEventosRepository
    {
        public Task<int> registrar(Evento Evento);
        public Task<IEnumerable<Evento>> GetByFilter(Evento Evento);
    }
}