using Project_OLP_Rest.Domain;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IModuleService : IGenericService<Module>
    {
        /// <summary>
        /// Includes all module records
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        IEnumerable<Module> GetRecords(int moduleId);
    }
}
