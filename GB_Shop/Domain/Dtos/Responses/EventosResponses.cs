using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class EventosResponses
    {
        public int IdEvento { get; set; }

        public DateTime FechaEvento{get; set;}

        public TimeSpan? HoraEven{get; set;}

        public string UbicacionEvento{get; set;}

        public string GeoUbicacion{get; set;}

        public int? CantPersonas{get; set;}

        public string CaracteristicasEvento{get; set;}

        public int? IdPatrocinador{get; set;}

        public int? IdConsideraciones{get; set;}


    }
}