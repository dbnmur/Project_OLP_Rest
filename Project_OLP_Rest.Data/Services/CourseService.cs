using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(OLP_Context context) : base(context) { }

        public IEnumerable<Course> GetAll()
        {
            return _entities.ToList();
        }

        public override Course FindBy(Expression<Func<Course, bool>> predicate)
        {
            return _entities
                .Include(course => course.Modules)
                .Single(predicate);
        }
    }
}
