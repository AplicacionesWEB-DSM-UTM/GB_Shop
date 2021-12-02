using System;
using System.Collections.Generic;
using System.Linq;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Interfaces;

namespace GB_Shop.Applications
{
    public class DenunciaServices : IDenunciaServices
    {
        public DenunciaResponseDto ObjectToDto(Denuncia Denuncia)
        {
            return new DenunciaResponseDto
            (
                FechaDenuncia : Denuncia.FechaDen, 
                MotivoDenuncia : Denuncia.IdMotivo,
                DescripcionLugar : Denuncia.DescLugar,
                GeoUbicacion : Denuncia.GeoUbiDen,
                Colonia : Denuncia.Colonia,
                Foto : Denuncia.Foto == null ? string.Empty : Denuncia.Foto.Foto1
            );
        }

        public Denuncia ResponseToObject(DenunciaResponseDto dto)
        {
            if(!validateEntity(dto))
            {
                return null;
            }
            
            var Denuncia = new Denuncia{
                FechaDen = DateTime.Now,
                IdMotivo = dto.MotivoDenuncia,
                DescLugar = dto.DescripcionLugar,
                GeoUbiDen = dto.GeoUbicacion,
                Colonia = dto.Colonia,
                IdFoto = 0,
                Foto = new Foto{
                    IdFoto = 0,
                    Foto1 = dto.Foto,
                }
            };

            return Denuncia;
        }

        public Denuncia DtoToObject(DenunciaFilterDto dto)
        {
            if((dto.Id <= 0) && dto.MotivoDenuncia <= 0 && string.IsNullOrEmpty(dto.GeoUbicacion) && string.IsNullOrEmpty(dto.Colonia))
            {
                return null;
            }

            var Denuncia = new Denuncia{
                IdReporte = dto.Id,
                FechaDen = default(DateTime),
                IdMotivo = dto.MotivoDenuncia,
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

        public bool validateEntity(DenunciaResponseDto Denuncia)
        {
            if(Denuncia.MotivoDenuncia <= 0)
            {
                return false;
            }
            if(string.IsNullOrEmpty(Denuncia.DescripcionLugar))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Denuncia.GeoUbicacion))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Denuncia.Colonia))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Denuncia.Foto))
            {
                return false;
            }
            return true;
        }
    }
}