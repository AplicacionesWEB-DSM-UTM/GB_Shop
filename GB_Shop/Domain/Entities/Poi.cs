using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Poi
    {
        public int IdPoi { get; set; }
        public int? Rango { get; set; }
        public string Colonia { get; set; }
        public string GeoUbiDen { get; set; }
        public int? Confirmar { get; set; }
        public int? Rechazar { get; set; }
        public int? IdMotivo { get; set; }

        public virtual MotivosDenuncium IdMotivoNavigation { get; set; }
    }
}
