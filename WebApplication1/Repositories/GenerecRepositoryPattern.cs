using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wECommerce.Repositories
{
    public interface IGenerecRepositoryPattern<T> where T : class
    {
        Task<T> FindAsync(object id);
        Task AddAsync(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
