using System;

namespace GB_Shop.Domain.Dtos
{
    public record POIResponseDto(int? Distancia, string Colonia, string Geo_Ubicacion, string Confirmacion, string Rechazar, int IdMotivo);
}