using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Entities;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ProdusRepository
{
    public class ProdusRepository : GenericRepository<Produs>, IProdusRepository
    {
        public ProdusRepository(ProiectContext context) : base(context) { }
        public async Task<Produs> GetByName(string name)
        {
            return await _context.Produse.Where(c => c.NumeProdus.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
