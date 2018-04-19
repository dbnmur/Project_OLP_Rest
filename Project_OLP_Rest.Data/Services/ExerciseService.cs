using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Services
{
    public class ExerciseService : GenericService<Exercise>, IExerciseService
    {
        public ExerciseService(OLP_Context context) : base(context) { }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
