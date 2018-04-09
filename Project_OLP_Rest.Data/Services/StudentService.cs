using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(OLP_Context context) : base(context)
        {
        }
        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
