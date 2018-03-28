using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    class TeacherService : Service
    {
        protected TeacherService(OLP_Context context) : base(context) { }

        public void Add(Teacher newTeacher)
        {
            _context.Add(newTeacher);
            _context.SaveChanges();
        }

        /* TODO FIX
        public Teacher Get(int id)
        {
            return _context.Teacher.FirstOrDefault(teacher => teacher.TeacherId == id);
        }
        */
    }
}
