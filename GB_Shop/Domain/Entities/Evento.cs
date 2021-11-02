using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Evento
    {
        public int IdEven { get; set; }
        public string NameEven { get; set; }
        public DateTime FechaEven { get; set; }
        public TimeSpan HoraEven { get; set; }
        public string UbicEven { get; set; }
        public int CantPersonEven { get; set; }
        public string CaracteristicasEven { get; set; }
    }
}
