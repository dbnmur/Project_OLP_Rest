﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class GroupCourse : Entity
    {   
        public int GroupId { get; set; }
        public Group Group  { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
