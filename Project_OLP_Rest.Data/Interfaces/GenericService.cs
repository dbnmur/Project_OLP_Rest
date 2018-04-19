using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project_OLP_Rest.Data.Services;
using Project_OLP_Rest.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public abstract class GenericService<T> : Service, IGenericService<T> where T : Entity
    {
        protected DbSet<T> _entities;

        protected GenericService(OLP_Context context) : base(context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            EntityEntry entityEntry = await _entities.AddAsync(entity);
            _context.SaveChanges();
            return (T)entityEntry.Entity;
        }

        public virtual async Task Delete(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return _entities.AnyAsync(predicate);
        }
    }
}
