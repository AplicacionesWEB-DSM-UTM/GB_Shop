using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Patrocinadore
    {
        public int IdPatrocinador { get; set; }
        public string Patrocinador { get; set; }

        public virtual Evento IdPatrocinadorNavigation { get; set; }
    }
}
