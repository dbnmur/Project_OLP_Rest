using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(OLP_Context context) : base(context) { }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public override async Task<Course> FindBy(Expression<Func<Course, bool>> predicate)
        {
            return await _entities
                .Include(course => course.Modules)
                .Include(course => course.ChatBot)
                .SingleAsync(predicate);
        }
    }
}
