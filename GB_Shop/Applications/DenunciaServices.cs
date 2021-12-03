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
                Foto : ""
            );
        }

        public Denuncia ResponseToObject(DenunciaResponseDto dto, int id)
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
                IdFoto = id
            };

            return Denuncia;
        }

        public Foto ResponseToFoto(DenunciaResponseDto dto)
        {
            if(!validateEntity(dto))
            {
                return null;
            }
            
            var Foto = new Foto{
                Foto1 = dto.Foto
            };

            return Foto;
        }

        public Denuncia DtoToObject(DenunciaFilterDto dto)
        {
            if((dto.MotivoDenuncia <= 0) && string.IsNullOrEmpty(dto.Colonia) && (dto.FechaDenuncia == default(DateTime)))
            {
                return null;
            }

            var Denuncia = new Denuncia{
                FechaDen = dto.FechaDenuncia,
                IdMotivo = dto.MotivoDenuncia,
                Colonia = dto.Colonia
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