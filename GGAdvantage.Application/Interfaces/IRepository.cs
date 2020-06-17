using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GGAdvantage.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {

        Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            params Expression<Func<T, object>>[] includeExpressions);

        Task<T> GetByIDAsync(object id);

        Task<bool> InsertAsync(T entity);

        Task<bool> DeleteAsync(object id);

        Task<bool> DeleteAsync(T entity);

        Task<bool> UpdateAsync(T entity);

    }
}

