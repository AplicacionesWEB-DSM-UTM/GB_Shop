using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Foto
    {
        public int Id { get; set; }
        public string Fotos { get; set; }

        public virtual Reporte IdNavigation { get; set; }
    }
}
