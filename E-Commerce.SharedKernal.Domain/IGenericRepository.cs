using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public interface IGenericRepository<T, TKey>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(TKey id);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Update(T entity);
        Task<int> save();
    }
}
