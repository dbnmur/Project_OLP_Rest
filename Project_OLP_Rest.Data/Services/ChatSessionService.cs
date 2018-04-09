using System.Collections.Generic;
using System.Linq;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data.Services
{
    public class ChatSessionService : GenericService<ChatSession>, IChatSessionService
    {
        public ChatSessionService(OLP_Context context) : base(context) { }

        public IEnumerable<ChatSession> GetAll()
        {
            return _entities.ToList();
        }
    }
}
