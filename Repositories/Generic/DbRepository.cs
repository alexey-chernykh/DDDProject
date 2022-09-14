using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Generic
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IDbEntity
    {
        DbContext _context;

        public DbRepository(DbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public IQueryable<T> AllItems => _context.Set<T>();

        public async Task<bool> AddItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await SaveChangesAsync() > 0;
        }
        public async Task<bool> AddItemsAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            T candidate = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (candidate != null)
            {
                _context.Set<T>().Remove(candidate);
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<T> GetItemAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> GhangeItemAsync(T item)
        {
            _context.Entry<T>(item).State = EntityState.Modified;
            return await SaveChangesAsync() > 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return -1;
            }
        }

        public async Task<List<T>> ToListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

    }
}
