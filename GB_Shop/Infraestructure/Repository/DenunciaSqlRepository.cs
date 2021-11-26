using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Infraestructure.Data;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Infraestructure.Repository
{
    public class DenunciaSqlRepository
    {
        private readonly GBishopContext _context;

        public DenunciaSqlRepository()
        {
            _context = new GBishopContext();
        }

        public string reportar(Denuncia Denuncia)
        {
            if (Denuncia == null)
            {
                return "Datos Vacios, Porfavor Inserte Todos Los Campos";
            }
            else
            {
                return "Reporte Exitoso";
            }
        }

        public IEnumerable<Denuncia> GetByFilter(Denuncia Denuncia)
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

            return query;
        }
    }
}