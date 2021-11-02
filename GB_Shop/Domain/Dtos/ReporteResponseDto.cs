using System;

namespace GB_Shop.Domain.Dtos
{
    public record ReporteResponseDto(DateTime FechaDenuncia, string MotivoDenuncia, string DescripcionLugar, string GeoUbicacion, string Colonia, string Foto);
}