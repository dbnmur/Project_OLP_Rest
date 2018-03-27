using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerUserID { get; set; }
        //M to M
        public List<Group> Groups { get; set; }

        public List<Teacher> Teachers { get; set; }

        //O to M
        
        public List<Module> Modules { get; set; }

    }
}
