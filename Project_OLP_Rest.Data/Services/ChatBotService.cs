using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Services
{
    public class ChatBotService : GenericService<ChatBot>, IChatBotService
    {
        public ChatBotService(OLP_Context context) : base(context) { }

        public async Task<IEnumerable<ChatBot>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
    }
}
