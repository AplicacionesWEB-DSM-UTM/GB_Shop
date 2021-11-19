using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Infraestructure.Data;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Infraestructure.Repository
{
    public class ReporteSqlRepository
    {
        private readonly GB_ShopContext _context;

        public ReporteSqlRepository()
        {
            _context = new GB_ShopContext();
        }

        public string reportar(Reporte reporte)
        {
            if (reporte == null)
            {
                return "Datos Vacios, Porfavor Inserte Todos Los Campos";
            }
            else
            {
                return "Reporte Exitoso";
            }
        }

        public IEnumerable<Reporte> GetByFilter(Reporte reporte)
        {
            if(reporte == null)
            {
                return new List<Reporte>();
            }

            var query = _context.Reportes.Select(x => x);

            if(reporte.Id > 0)
            {
                query = query.Where(x => x.Id == reporte.Id);
            }
            if(!String.IsNullOrEmpty(reporte.MotivoDenuncia))
            {
                query = query.Where(x => x.MotivoDenuncia == reporte.MotivoDenuncia);
            }
            if (!string.IsNullOrEmpty(reporte.GeoUbi))
            {
                query = query.Where(x => x.GeoUbi == reporte.GeoUbi);
            }
            if (!string.IsNullOrEmpty(reporte.Colonia))
            {
                query = query.Where(x => x.Colonia == reporte.Colonia);
            }

            return query;
        }
    }
}