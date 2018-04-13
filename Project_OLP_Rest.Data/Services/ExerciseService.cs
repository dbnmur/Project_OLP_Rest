using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Project_OLP_Rest.Data.Services
{
    public class ExerciseService : GenericService<Exercise>, IExerciseService
    {
        protected ExerciseService(OLP_Context context) : base(context) { }

        public IEnumerable<Exercise> GetAll()
        {
            return _entities.ToList();
        }
    }
}
