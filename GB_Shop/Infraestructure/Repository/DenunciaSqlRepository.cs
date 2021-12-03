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
        private readonly GB_shopContext _context;

        public DenunciaSqlRepository(GB_shopContext context)
        {
            _context = context;
        }

        public async Task<int> reportar(Denuncia Denuncia)
        {
            try
            {
                var entity = Denuncia;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if (rows != 1)
                {
                    throw new Exception("Ocurrió un fallo al intentar guardar el registro, verifica tu información...");
                }
                return entity.IdReporte;

            }
            catch(DbUpdateException /*exEF*/)
            {
                throw new Exception("Fallos al intentar acceder al repositorio de datos...");
            }
        }
        public int insertFoto(Foto Foto)
        {
            try
            {
                var entity = Foto;
                _context.Add(entity);
                var rows = _context.SaveChanges();

                if (rows != 1)
                {
                    throw new Exception("Ocurrió un fallo al intentar guardar el registro, verifica tu información...");
                }
                else
                {
                    return entity.IdFoto;
                }
            }
            catch(DbUpdateException /*exEF*/)
            {
                throw new Exception("Fallos al intentar acceder al repositorio de datos...");
            }
        }

        public async Task<IEnumerable<Denuncia>> GetByFilter(Denuncia Denuncia)
        {
            if(Denuncia == null)
            {
                return new List<Denuncia>();
            }
            
            try
            {

                var query = _context.Denuncias.Select(x => x);

                if(Denuncia.IdMotivo > 0)
                {
                    query = query.Where(x => x.IdMotivo == Denuncia.IdMotivo);
                }
                if (!string.IsNullOrEmpty(Denuncia.Colonia))
                {
                    query = query.Where(x => x.Colonia == Denuncia.Colonia);
                }
                if (Denuncia.FechaDen != default(DateTime))
                {
                    query = query.Where(x => x.FechaDen == Denuncia.FechaDen);
                }

                return await query.ToListAsync();
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }

        public async Task<Denuncia> GetById(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return null;
                }
                
                var query = await _context.Denuncias.FirstOrDefaultAsync(x => x.IdReporte == id);
                return query;
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }

        public async Task<int> CountByFilter(Denuncia Denuncia)
        {
            try
            {
                var query =  _context.Denuncias.Select(x => x);

                var result = query.CountAsync();
                
                if(Denuncia == null)
                {
                    return await result;
                }
                if(Denuncia.IdMotivo > 0)
                {
                    result = query.CountAsync(x => x.IdMotivo == Denuncia.IdMotivo);
                }
                if (!string.IsNullOrEmpty(Denuncia.Colonia))
                {
                    result = query.CountAsync(x => x.Colonia == Denuncia.Colonia);
                }

                return await result;
            }
            catch(Exception)
            {
                throw new Exception("Fallos al intentar realizar la peticion...");
            }
        }
    }
}