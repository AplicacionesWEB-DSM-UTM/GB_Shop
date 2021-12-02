using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos;

namespace GB_Shop.Domain.Interfaces
{
    public interface IDenunciaServices
    {
        public DenunciaResponseDto ObjectToDto(Denuncia Denuncia);
        public Denuncia ResponseToObject(DenunciaResponseDto dto);
        public Denuncia DtoToObject(DenunciaFilterDto dto);
        public bool validateEntity(DenunciaResponseDto Denuncia);
    }
}