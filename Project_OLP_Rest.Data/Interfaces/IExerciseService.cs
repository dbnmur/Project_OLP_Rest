using Project_OLP_Rest.Domain;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IExerciseService : IGenericService<Exercise>
    {
        IEnumerable<Exercise> GetAll();
    }
}
