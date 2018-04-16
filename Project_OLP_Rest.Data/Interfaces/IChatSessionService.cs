using Project_OLP_Rest.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IChatSessionService : IGenericService<ChatSession>
    {
        Task<IEnumerable<ChatSession>> GetAll();
    }
}
