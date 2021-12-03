using System;

namespace GB_Shop.Domain.Dtos.Responses
{
    public class DenunciaFilterResponse
    {
        public int MotivoDenuncia { get; set; }

        public string Colonia{ get; set; }

        public DateTime FechaDenuncia{get; set;}
    }
}