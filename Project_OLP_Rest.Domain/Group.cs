using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GroupCourse> GroupCourses { get; set; }
        public List<Student> Students { get; set; }
    }
}
