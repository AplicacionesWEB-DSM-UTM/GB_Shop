using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Domain.Interfaces
{
    public interface IPOIRepository
    {
        Task<Poi> GetById(int id);
    }
}