using System;

namespace GB_Shop.Domain.Dtos
{
    public record DenunciaFilterDto(int Id, string MotivoDenuncia, string GeoUbicacion, string Colonia);
}