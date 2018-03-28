using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface ICourseService : IGenericService<Course>
    {
        IEnumerable<Course> GetAll();
    }
}
