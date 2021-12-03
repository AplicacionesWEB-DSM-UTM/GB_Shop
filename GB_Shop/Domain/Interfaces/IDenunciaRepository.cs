using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GB_Shop.Domain.Entities;

namespace GB_Shop.Domain.Interfaces
{
    public interface IDenunciaRepository
    {
        public Task<int> reportar(Denuncia Denuncia);
        public Task<IEnumerable<Denuncia>> GetByFilter(Denuncia Denuncia);
        public int insertFoto(Foto Foto);
    }
}