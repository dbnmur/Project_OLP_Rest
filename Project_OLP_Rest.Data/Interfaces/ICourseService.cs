using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface ICourseService : IGenericService<Course>
    {
        /// <summary>
        /// Fetches all courses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Course>> GetAll();
    }
}
