using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class TeacherCourse : Entity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
