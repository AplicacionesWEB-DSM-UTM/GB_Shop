using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class PoiResponse
    {
        public int IdPoi { get; set; }
        public int? Distancia { get; set; }
        public string Colonia { get; set; }
        public string GeoUbicacion { get; set; }
        public int Confirmaciones { get; set; }
        public int Rechazar { get; set; }
        public int? IdMotivo { get; set; }

    }

}
