using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course Course{ get; set; }

        public List<Record> Records { get; set; }
    }
}
