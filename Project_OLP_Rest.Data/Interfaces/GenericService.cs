using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Domain;
using System;
using System.Linq.Expressions;

namespace Project_OLP_Rest.Data.Interfaces
{
    public abstract class GenericService<T> : IGenericService<T> where T : Entity
    {
        protected OLP_Context _context;
        protected DbSet<T> _entities;

        public GenericService(OLP_Context context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public T Create(T entity)
        {
            T addedEntity = _entities.Add(entity).Entity;
            _context.SaveChanges();
            return addedEntity;
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.SingleAsync(predicate).Result;
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
