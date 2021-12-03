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
            try
            {
                if(id <= 0)
                {
                    return null;
                }
                
                var query = await _context.Pois.FirstOrDefaultAsync(x => x.IdPoi == id);
                return query;
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }

        public async Task<int> reportar(Poi Poi)
        {
            try
            {
                var entity = Poi;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if (rows != 1)
                {
                    throw new Exception("Ocurrió un fallo al intentar guardar el registro, verifica tu información...");
                }
                return entity.IdPoi;

            }
            catch(DbUpdateException /*exEF*/)
            {
                throw new Exception("Fallos al intentar acceder al repositorio de datos...");
            }
        }

        public async Task<IEnumerable<Poi>> GetByFilter(Poi Poi)
        {
            if(Poi == null)
            {
                return new List<Poi>();
            }
            
            try
            {

                var query = _context.Pois.Select(x => x);

                if(Poi.IdMotivo > 0)
                {
                    query = query.Where(x => x.IdMotivo == Poi.IdMotivo);
                }
                if (!string.IsNullOrEmpty(Poi.Colonia))
                {
                    query = query.Where(x => x.Colonia == Poi.Colonia);
                }

                return await query.ToListAsync();
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }

        public async Task<int> CountByFilter(Poi Poi)
        {
            try
            {
                var result = await _context.Pois.CountAsync();
                
                if(Poi == null)
                {
                    return result;
                }
                if(Poi.IdMotivo > 0)
                {
                    result = _context.Pois.Count(x => x.IdMotivo == Poi.IdMotivo);
                }
                if (!string.IsNullOrEmpty(Poi.Colonia))
                {
                    result = _context.Pois.Count(x => x.Colonia == Poi.Colonia);
                }
                return result;
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }
    }
}