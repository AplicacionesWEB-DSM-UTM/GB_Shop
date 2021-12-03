using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Infraestructure.Data;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GB_Shop.Infraestructure.Repository
{
    public class POISqlRepository : IPOIRepository
    {
        private readonly GB_shopContext _context;

        public POISqlRepository(GB_shopContext context)
        {
            _context = context;
        }

        public async Task<Poi> GetById(int id)
        {            
            var query = await _context.Pois.Include(x => x.IdPoi).FirstOrDefaultAsync(x => x.IdPoi == id);
            return query;
        }
    }
}