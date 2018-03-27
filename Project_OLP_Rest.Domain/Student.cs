using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Student : User
    {
        public Group Group { get; set; }
    }
}
