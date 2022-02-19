using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ProiectContext _context;
        /// Cand se creeaza repository-ul, se creeaza si contextul
        /// Cand se apeleaza destructorul pentru repository, se distruge si contextul
        public GenericRepository(ProiectContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);     
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
///IQueryable - colectie - tine minte query-ul - cum se iau datele
///IEnumerable - colectie - in memory
///AsNoTracking - putem modifica datele in program, dar nu vor fi alterate in baza de date
///Create, Update, Delete, CreateRange, DeleteRange se executa in memorie. se vor salva in baza de date cand dam save
///async - thread-ul nu mai sta blocat