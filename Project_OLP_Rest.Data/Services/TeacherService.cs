using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public class TeacherService : GenericService<Teacher>, ITeacherService
    {
        public TeacherService(OlpContext context) : base(context)
        {

        }
        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
