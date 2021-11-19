using System;

namespace GB_Shop.Domain.Dtos
{
    public record ReporteFilterDto(int Id, string MotivoDenuncia, string GeoUbicacion, string Colonia);
}