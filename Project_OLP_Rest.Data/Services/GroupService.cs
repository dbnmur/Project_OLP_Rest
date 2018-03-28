using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public class GroupService : GenericService<Group>, IGroupService
    {
        public GroupService(OLP_Context context) : base(context)
        {
        }

        public IEnumerable<Group> GetAll()
        {
            // Some implementation DO IT
            throw new NotImplementedException();
        }



    }
}
