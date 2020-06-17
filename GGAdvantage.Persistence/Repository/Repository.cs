using GGAdvantage.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GGAdvantage.Persistence.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly GGAdventageDbContext _context;
        private readonly DbSet<T> dbSet;

        public Repository(GGAdventageDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? take = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = dbSet;

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (take != null)
            {
                query.Take((int)take);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            try
            {
                T entityToDelete = await dbSet.FindAsync(id);
                await DeleteAsync(entityToDelete);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        //public virtual async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await _context.Set<T>().SingleOrDefaultAsync(expression);
        //}

        //public virtual async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await _context.Set<T>().Where(expression).ToListAsync();
        //}

        //public virtual async Task<T> GetAsync(object key)
        //{
        //    return await _context.Set<T>().FindAsync(key);
        //}

        //public virtual async Task<ICollection<T>> GetAllAsync()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public virtual async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await _context.Set<T>().CountAsync(expression);
        //}

        //public virtual async Task<T> CreateAsync(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //    await _context.SaveChangesAsync();

        //    return entity;
        //}

        //public virtual async Task<T> UpdateAsync(T entity, object key)
        //{
        //    if (entity == null)
        //        return null;

        //    T exist = await _context.Set<T>().FindAsync(key);

        //    if (exist != null)
        //    {
        //        _context.Entry(exist).CurrentValues.SetValues(entity);
        //        await _context.SaveChangesAsync();
        //    }

        //    return entity;
        //}

        //public virtual async Task<T> DeleteAsync(T entity)
        //{
        //    if (entity == null)            
        //        return null;           

        //    _context.Remove(entity);
        //    await _context.SaveChangesAsync();

        //    return entity;
        //}

    }
}
