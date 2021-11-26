using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Applications
{
    public class DenunciaServices
    {
        public DenunciaResponseDto ObjectToDto(Denuncia Denuncia)
        {
            return new DenunciaResponseDto
            (
                FechaDenuncia : Denuncia.FechaDen, 
                MotivoDenuncia : Denuncia.MotivoDen,
                DescripcionLugar : Denuncia.DescLugar,
                GeoUbicacion : Denuncia.GeoUbiDen,
                Colonia : Denuncia.Colonia,
                Foto : Denuncia.Foto == null ? string.Empty : Denuncia.Foto.Foto1
            );
        }

        public Denuncia ResponseToObject(DenunciaResponseDto dto)
        {
            if(dto.FechaDenuncia == default(DateTime) && string.IsNullOrEmpty(dto.MotivoDenuncia) && string.IsNullOrEmpty(dto.DescripcionLugar) && string.IsNullOrEmpty(dto.GeoUbicacion) && string.IsNullOrEmpty(dto.Colonia) && string.IsNullOrEmpty(dto.Foto))
            {
                return null;
            }
            
            var Denuncia = new Denuncia{
                FechaDen = DateTime.Now,
                MotivoDen = dto.MotivoDenuncia,
                DescLugar = dto.DescripcionLugar,
                GeoUbiDen = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                Foto = new Foto{
                    IdFoto = 0,
                    Foto1 = dto.Foto,
                }
            };

            return Denuncia;
        }

        public Denuncia DtoToObject(DenunciaFilterDto dto)
        {
            if((dto.Id <= 0) && string.IsNullOrEmpty(dto.MotivoDenuncia) && string.IsNullOrEmpty(dto.GeoUbicacion) && string.IsNullOrEmpty(dto.Colonia))
            {
                return null;
            }

            var Denuncia = new Denuncia{
                IdReporte = dto.Id,
                FechaDen = default(DateTime),
                MotivoDen = dto.MotivoDenuncia,
                DescLugar = string.Empty,
                GeoUbiDen = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                Foto = new Foto{
                    IdFoto = 0,
                    Foto1 = string.Empty
                }
            };

            return Denuncia;
        }
    }
}