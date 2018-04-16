using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IModuleService : IGenericService<Module>
    {
        /// <summary>
        /// Includes all module records
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<IEnumerable<Module>> GetAll();
    }
}
