using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Domain.Interfaces
{
    public interface IPOIRepository
    {
        public Task<int> reportar(Poi Poi);
        public Task<IEnumerable<Poi>> GetByFilter(Poi Poi);
        public Task<Poi> GetById(int id);
        public Task<int> CountByFilter(Poi Poi);
    }
}