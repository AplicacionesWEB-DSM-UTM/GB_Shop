using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class DenunciaResponse
    {
        public int ID { get; set; }
        public DateTime FechaDenuncia { get; set; }
        public int MotivoDenuncia { get; set; }
        public string DescripcionLugar { get; set; }
        public string GeoUbicacion { get; set; }
        public string Colonia {get; set;}
        public string Foto {get; set;}
    }
}