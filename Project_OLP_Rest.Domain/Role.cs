using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCore.Domain
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        List<User> Users { get; set; }
    }
}
