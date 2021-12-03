using System; 
namespace GB_Shop.Domain.Dtos
{
 
    
        public record EventosResponseDto(int IdEvento, DateTime? FechaEvento, TimeSpan? HoraEvento, string UbicacionEvento, string GeoUbicacion, int? CantPersonas, string CaracteristicasEvento, int? IdPatrocinador, int? IdConsideraciones);
    
}