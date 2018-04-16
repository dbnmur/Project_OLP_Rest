using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_OLP_Rest.Data.Services
{
    public class GroupService : GenericService<Group>, IGroupService
    {
        public GroupService(OLP_Context context) : base(context) { }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
