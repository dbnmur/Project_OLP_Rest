using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IGroupService : IGenericService<Group>
    {
        /// <summary>
        /// Fetches all available groups
        /// </summary>
        /// <returns></returns>
        IEnumerable<Group> GetAll();
    }
}
