using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace wECommerce.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryPattern<T> where T : class
    {
        private AppDbContext context = null;
        private DbSet<T> table = null;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public void Remove(T entity)
        {
            table.Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
