using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    public class GroupSeeder : Seeder<Group>
    {
        public GroupSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Group()
            {
                Name = "Some name",
                Description = "Some description",
                
            });

            _entities.Add(new Group()
            {
                Name = "Some other name",
                Description = "Some other description"
            });

            _context.SaveChanges();
        }
    }
}
