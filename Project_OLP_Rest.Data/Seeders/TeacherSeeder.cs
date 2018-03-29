using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    class TeacherSeeder : Seeder<Teacher>
    {
        public TeacherSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Teacher()
            {
                FirstName = "Vardenis",
                LastName = "Pavardenis",
                Email = "vardenis@pavardenis.com",
            });
        }
    }
}
