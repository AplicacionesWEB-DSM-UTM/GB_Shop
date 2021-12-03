using System;
using System.Collections.Generic;

#nullable disable

namespace GB_Shop.Domain.Entities
{
    public partial class MotivosDenuncium
    {
        public MotivosDenuncium()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int IdMotivo { get; set; }
        public string Motivos { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
