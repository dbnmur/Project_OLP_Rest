using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IExerciseService : IGenericService<Exercise>
    {
        Task<IEnumerable<Exercise>> GetAll();
    }
}
