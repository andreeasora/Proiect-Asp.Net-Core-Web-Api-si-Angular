
using ProjectDAW.Entities;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ComandaRepository
{
    public interface IComandaRepository : IGenericRepository<Comanda>
    {
        Task<Comanda> GetByTipPlata(string tipPlata);

    }
}
