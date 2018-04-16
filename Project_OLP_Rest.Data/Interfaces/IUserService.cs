using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<IEnumerable<User>> GetAll();
    }
}
