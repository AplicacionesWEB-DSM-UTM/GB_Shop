using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Foto
    {
        public int IdFoto { get; set; }
        public string Foto1 { get; set; }

        public virtual Denuncia IdFotoNavigation { get; set; }
    }
}
