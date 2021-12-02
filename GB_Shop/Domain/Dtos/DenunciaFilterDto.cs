using System;

namespace GB_Shop.Domain.Dtos
{
    public record DenunciaFilterDto(int Id, int MotivoDenuncia, string GeoUbicacion, string Colonia);
}