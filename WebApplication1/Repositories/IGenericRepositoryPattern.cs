using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wECommerce.Repositories
{
    public interface IGenericRepositoryPattern<T>  where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
