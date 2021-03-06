﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
   public abstract class User : Entity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
