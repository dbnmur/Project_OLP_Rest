using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IGenericService<T>
    {
        Task<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(Expression<Func<T, bool>> predicate);
    }
}
