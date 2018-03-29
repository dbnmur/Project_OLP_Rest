using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    class CourseSeeder : Seeder<Course>
    {
        public CourseSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Course()
            {
               Name = "Web services" ,
               Description = "Web services description",
            });

            _entities.Add(new Course()
            {
                Name = "Web security",
                Description = "Web security description",
            });

            _context.SaveChanges();
        }
    }
}
