using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Patrocinadore
    {
        public int IdPatrocinadores { get; set; }
        public string Patrocinador { get; set; }

        public virtual Evento IdPatrocinadoresNavigation { get; set; }
    }
}
