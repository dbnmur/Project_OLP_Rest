using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Domain;
using System;
using System.Linq.Expressions;

namespace Project_OLP_Rest.Data.Interfaces
{
    public abstract class GenericService<T> : IGenericService<T> where T : Entity
    {
        private OLP_Context _context;
        protected DbSet<T> _entities;

        public GenericService(OLP_Context context) { _context = context; }

        public void Create(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
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
