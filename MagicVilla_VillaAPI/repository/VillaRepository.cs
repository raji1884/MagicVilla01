using MagicVilla_VillaAPI.data;
using MagicVilla_VillaAPI.models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContex _db;

        public object villamodels => throw new NotImplementedException();

        public VillaRepository(ApplicationDbContex db)
        {
            _db = db;
        }
        public async Task CreateAsync(Villamodel entity)
        {
            await _db.villamodels.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Villamodel> GetAsync(Expression<Func<Villamodel, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villamodel> query = _db.villamodels;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Villamodel>> GetAllAsync(Expression<Func<Villamodel, bool>> filter = null)
        {
            IQueryable<Villamodel> query = _db.villamodels;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }

        public async Task RemoveAsync(Villamodel entity)
        {
            _db.villamodels.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async  Task UpdateAsync(Villamodel entity)
        {
            _db.villamodels .Update(entity);
            await SaveAsync();
        }

        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
