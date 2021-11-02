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

        public string reportar(string MotivoDenuncia, string DescripLugar, string GeoUbi, string Colonia, string Fotos)
        {
            if (MotivoDenuncia != string.Empty && DescripLugar != string.Empty && GeoUbi != string.Empty && Colonia != string.Empty && Fotos != string.Empty)
            {
                return "Reporte Exitoso " + MotivoDenuncia + " " + DescripLugar + " " + GeoUbi + " " + Colonia + " " + Fotos;
            }
            else
            {
                return "Datos Vacios, Porfavor Inserte Todos Los Campos";
            }
        }
    }
}