using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCore.Domain
{
   public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        
    }
}
