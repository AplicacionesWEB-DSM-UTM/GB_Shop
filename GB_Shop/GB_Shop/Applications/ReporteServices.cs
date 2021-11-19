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

        public Reporte ResponseToObject(ReporteResponseDto dto)
        {
            if(dto.FechaDenuncia == default(DateTime) && string.IsNullOrEmpty(dto.MotivoDenuncia) && string.IsNullOrEmpty(dto.DescripcionLugar) && string.IsNullOrEmpty(dto.GeoUbicacion) && string.IsNullOrEmpty(dto.Colonia) && string.IsNullOrEmpty(dto.Foto))
            {
                return null;
            }
            
            var reporte = new Reporte{
                FechaDenuncia = DateTime.Now,
                MotivoDenuncia = dto.MotivoDenuncia,
                DecripLugar = dto.DescripcionLugar,
                GeoUbi = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                Foto = new Foto{
                    Id = 0,
                    Fotos = dto.Foto,
                }
            };

            return reporte;
        }

        public Reporte DtoToObject(ReporteFilterDto dto)
        {
            if((dto.Id <= 0) && string.IsNullOrEmpty(dto.MotivoDenuncia) && string.IsNullOrEmpty(dto.GeoUbicacion) && string.IsNullOrEmpty(dto.Colonia))
            {
                return null;
            }

            var reporte = new Reporte{
                Id = dto.Id,
                FechaDenuncia = default(DateTime),
                MotivoDenuncia = dto.MotivoDenuncia,
                DecripLugar = string.Empty,
                GeoUbi = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                Foto = new Foto{
                    Id = 0,
                    Fotos = string.Empty
                }
            };

            return reporte;
        }
    }
}