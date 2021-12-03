using System;

namespace GB_Shop.Domain.Dtos
{
    public record POIResponseDto(string Colonia, string GeoUbicacion, int? Confirmaciones, int? Rechazar, int? IdMotivo);
}