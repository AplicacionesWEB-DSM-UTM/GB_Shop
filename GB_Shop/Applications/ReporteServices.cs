using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Applications
{
    public class ReporteServices
    {
        public ReporteResponseDto ObjectToDto(Reporte reporte)
        {
            return new ReporteResponseDto
            (
                FechaDenuncia : reporte.FechaDenuncia, 
                MotivoDenuncia : reporte.MotivoDenuncia,
                DescripcionLugar : reporte.DecripLugar,
                GeoUbicacion : reporte.GeoUbi,
                Colonia : reporte.Colonia,
                Foto : reporte.Foto == null ? string.Empty : reporte.Foto.Fotos
            );
        }
    }
}