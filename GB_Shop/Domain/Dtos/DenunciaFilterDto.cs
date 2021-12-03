using System;

namespace GB_Shop.Domain.Dtos
{
    public record DenunciaFilterDto(int MotivoDenuncia, string Colonia, DateTime FechaDenuncia);
}