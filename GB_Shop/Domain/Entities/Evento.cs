using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Evento
    {
        public int IdEven { get; set; }
        public DateTime? FechaEven { get; set; }
        public TimeSpan? HoraEven { get; set; }
        public string UbicEven { get; set; }
        public string GeoUbiEve { get; set; }
        public int? CantPersonas { get; set; }
        public string CaractEven { get; set; }
        public int? IdPatrocinador { get; set; }
        public int? IdConsideraciones { get; set; }

        public virtual ConsideracionesEsp ConsideracionesEsp { get; set; }
        public virtual Patrocinadore Patrocinadore { get; set; }
    }
}
