using System; 

namespace GB_Shop.Domain.Dtos
{
   
        public record EventosFilterDto(int IdEven, string UbicacionEvento, string GeoUbicacion, int CantPersonas, string CaracteristicasEvento, int IdPatrocinador, int IdConsideraciones);
    
 }
