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
    public class DenunciaSqlRepository : IDenunciaRepository
    {
        private readonly GBishopContext _context;

        public DenunciaSqlRepository(GBishopContext context)
        {
            _context = context;
        }

        public async Task<int> reportar(Denuncia Denuncia)
        {
            var entity = Denuncia;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if (rows != 1)
            {
                throw new Exception("Ocurrió un fallo al intentar guardar el registro, verifica tu información...");
            }
            else
            {
                return entity.IdReporte;
            }
        }

        public async Task<IEnumerable<Denuncia>> GetByFilter(Denuncia Denuncia)
        {
            if(Denuncia == null)
            {
                return new List<Denuncia>();
            }

            var query = _context.Denuncias.Select(x => x);

            if(Denuncia.IdReporte > 0)
            {
                query = query.Where(x => x.IdReporte == Denuncia.IdReporte);
            }
            if(!String.IsNullOrEmpty(Denuncia.MotivoDen))
            {
                query = query.Where(x => x.MotivoDen == Denuncia.MotivoDen);
            }
            if (!string.IsNullOrEmpty(Denuncia.GeoUbiDen))
            {
                query = query.Where(x => x.GeoUbiDen == Denuncia.GeoUbiDen);
            }
            if (!string.IsNullOrEmpty(Denuncia.Colonia))
            {
                query = query.Where(x => x.Colonia == Denuncia.Colonia);
            }

            return await query.ToListAsync();
        }
    }
}