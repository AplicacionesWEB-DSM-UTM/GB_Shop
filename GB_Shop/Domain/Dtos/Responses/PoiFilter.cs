using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class PoiFilter
    {
        public string Colonia {get; set;}

        public int? Motivo {get; set;}

        public int? Confirmacion {get; set;}

        public int? Rechazos {get; set;}
    }
}