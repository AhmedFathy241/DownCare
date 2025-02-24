using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.IRepositories
{
    public interface IGenricRepository<T> where T : class
    {
        Task<T> CreateAsync(T model);
        Task<T> GetByIdAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
