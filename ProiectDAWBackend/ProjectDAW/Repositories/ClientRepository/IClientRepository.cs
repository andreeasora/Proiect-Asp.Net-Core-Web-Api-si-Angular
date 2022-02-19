using ProjectDAW.Entities;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ClientRepository
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByName(string name);
        Task<List<Client>> GetAllClientsWithAdress();
        Task<Client> GetByIdWithAdress(int id);
    }
}
