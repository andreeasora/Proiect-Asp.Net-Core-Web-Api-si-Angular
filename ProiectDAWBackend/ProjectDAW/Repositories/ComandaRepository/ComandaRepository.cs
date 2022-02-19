using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Entities;
using ProjectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.ComandaRepository
{
    public class ComandaRepository : GenericRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(ProiectContext context) : base(context) { }
        public async Task<Comanda> GetByTipPlata(string tipPlata)
        {
            return await _context.Comenzi.Where(c => c.TipPlata.Equals(tipPlata)).FirstOrDefaultAsync();
        }
    }
}
