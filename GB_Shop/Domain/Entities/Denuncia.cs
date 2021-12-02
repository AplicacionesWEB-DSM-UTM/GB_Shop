using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Denuncia
    {
        public int IdReporte { get; set; }
        public DateTime? FechaDen { get; set; }
        public int? IdMotivo { get; set; }
        public string DescLugar { get; set; }
        public string GeoUbiDen { get; set; }
        public string Colonia { get; set; }
        public int? IdFoto { get; set; }

        public virtual Foto Foto { get; set; }
    }
}
