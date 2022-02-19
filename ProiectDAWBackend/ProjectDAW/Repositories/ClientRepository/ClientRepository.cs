using Microsoft.EntityFrameworkCore;
using ProjectDAW.Entities;
using ProjectDAW.Data;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ClientRepository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ProiectContext context) : base(context) { }
        public async Task<List<Client>> GetAllClientsWithAdress()
        {
            return await _context.Clienti.Include(c => c.Adresa).ToListAsync();
        }

        public async Task<Client> GetByIdWithAdress(int id)
        {
            return await _context.Clienti.Include(c => c.Adresa).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByName(string name)
        {
            return await _context.Clienti.Where(c => c.Nume.Equals(name)).FirstOrDefaultAsync();
        }


    }
}
