using System;

namespace GB_Shop.Domain.Dtos
{
    public record DenunciaResponseDto(DateTime? FechaDenuncia, int? MotivoDenuncia, string DescripcionLugar, string GeoUbicacion, string Colonia, string Foto);
}