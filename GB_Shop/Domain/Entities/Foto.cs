using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class Foto
    {
        public Foto()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int IdFoto { get; set; }
        public string Foto1 { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
