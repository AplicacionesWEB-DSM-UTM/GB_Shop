using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Reporte
    {
        public int Id { get; set; }
        public DateTime FechaDenuncia { get; set; }
        public string MotivoDenuncia { get; set; }
        public string DecripLugar { get; set; }
        public string GeoUbi { get; set; }
        public string Colonia { get; set; }

        public virtual Foto Foto { get; set; }
    }
}
