using System; 

namespace GB_Shop.Domain.Dtos
{
   
        public record POIFilterDto(int IdPoi, string Colonia, string GeoUbicacion, int Confirmaciones, int Rechazar, int? IdMotivo);
    
 }
