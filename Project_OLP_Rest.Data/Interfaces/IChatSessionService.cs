using Project_OLP_Rest.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IChatSessionService : IGenericService<ChatSession>
    {
        IEnumerable<ChatSession> GetAll();
    }
}
