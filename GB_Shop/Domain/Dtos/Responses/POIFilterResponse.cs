using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class POIFilterResponse
    {
        public string Colonia {get; set;}

        public string Motivo {get; set;}

        public int Confirmacion {get; set;}

        public int Rechazos {get; set;}
    }
}