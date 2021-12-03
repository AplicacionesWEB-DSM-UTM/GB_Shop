using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class PoiResponse
    {
        public int IdPoi { get; set; }
        public int? Distancia { get; set; }
        public string Colonia { get; set; }
        public string Geo_Ubicacion { get; set; }
        public string Confirmacion { get; set; }
        public string Rechazar { get; set; }
        public int? IdMotivo { get; set; }

    }

}
