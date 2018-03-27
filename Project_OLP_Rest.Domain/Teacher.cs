using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Teacher: User
    {
        public List<TeacherCourse> TeacherCourses { get; set; }

    }
}
