using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCore.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerUserID { get; set; }

    }
}
