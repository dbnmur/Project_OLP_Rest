using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCore.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; }
    }
}
