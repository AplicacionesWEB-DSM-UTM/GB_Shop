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

       public async Task<int> registrar(Evento Evento)
        {
            var entity = Evento;
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
         public async Task<IEnumerable<Evento>> GetByFilter(Evento Evento)
        {
            if(Evento == null)
            {
                return new List<Evento>();
            }

            var query = _context.Eventos.Select(x => x);

            if(Evento.IdEven > 0)
            {
                query = query.Where(x => x.IdEven == Evento.IdEven);
            }
            if(Evento.FechaEven != default (DateTime))
            {
                query = query.Where(x => x.FechaEven == Evento.FechaEven);
            }
            if(Evento.HoraEven != default (TimeSpan))
            {
                query = query.Where(x => x.HoraEven == Evento.HoraEven);
            }
            if (!string.IsNullOrEmpty(Evento.UbicEven))
            {
                query = query.Where(x => x.UbicEven == Evento.UbicEven);
            }
            if (!string.IsNullOrEmpty(Evento.GeoUbiEve))
            {
                query = query.Where(x => x.GeoUbiEve == Evento.GeoUbiEve);
            }
            if (Evento.CantPersonas > 0) 
            {
                query = query.Where(x => x.CantPersonas == Evento.CantPersonas);
            }
             if(Evento.IdPatrocinador > 0)
            {
                query = query.Where(x => x.IdPatrocinador == Evento.IdPatrocinador);
            }
             if(Evento.IdConsideraciones > 0)
            {
                query = query.Where(x => x.IdConsideraciones == Evento.IdConsideraciones);
            }

            return await query.ToListAsync();
        }
    }
}