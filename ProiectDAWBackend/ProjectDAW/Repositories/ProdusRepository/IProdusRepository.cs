using ProjectDAW.Entities;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ProdusRepository
{
    public interface IProdusRepository : IGenericRepository<Produs>
    { 
        Task<Produs> GetByName(string name);
    }
}
