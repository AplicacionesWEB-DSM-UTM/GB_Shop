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
    public class EventosSqlRepository : IEventosRepository
    {
        private readonly GB_shopContext _context;

        public EventosSqlRepository(GB_shopContext context)
        {
            _context = context;
        }

       public async Task<int> registrar(Eventos Eventos)
        {
            var entity = Eventos;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if (rows != 1)
            {
                throw new Exception("Ocurrió un fallo al intentar guardar el registro, verifica tu información...");
            }
            else
            {
                return entity.IdEven;
            }
        }
         public async Task<IEnumerable<Eventos>> GetByFilter(Eventos Eventos)
        {
            if(Eventos == null)
            {
                return new List<Eventos>();
            }

            var query = _context.Eventos.Select(x => x);

            if(Eventos.IdEven > 0)
            {
                query = query.Where(x => x.IdEven == Eventos.IdEven);
            }
            if(Eventos.FechaEven != default (DateTime))
            {
                query = query.Where(x => x.FechaEven == Eventos.FechaEven);
            }
            if(Eventos.HoraEven != default (TimeSpan))
            {
                query = query.Where(x => x.HoraEven == Eventos.HoraEven);
            }
            if (!string.IsNullOrEmpty(Eventos.UbicEven))
            {
                query = query.Where(x => x.UbicEven == Eventos.UbicEven);
            }
            if (!string.IsNullOrEmpty(Eventos.GeoUbiEve))
            {
                query = query.Where(x => x.GeoUbiEve == Eventos.GeoUbiEve);
            }
            if (Eventos.CantPersonas > 0) 
            {
                query = query.Where(x => x.CantPersonas == Eventos.CantPersonas);
            }
             if(Eventos.IdPatrocinador > 0)
            {
                query = query.Where(x => x.IdPatrocinador == Eventos.IdPatrocinador);
            }
             if(Eventos.IdConsideraciones > 0)
            {
                query = query.Where(x => x.IdConsideraciones == Eventos.IdConsideraciones);
            }

            return await query.ToListAsync();
        }
    }
}