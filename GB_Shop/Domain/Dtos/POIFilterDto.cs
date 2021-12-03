using System; 

namespace GB_Shop.Domain.Dtos
{
   
        public record POIFilterDto(string Colonia, DateTime FechaDeEvento, string Motivo, int Confirmaciones, string Rechazos);
    
 }
