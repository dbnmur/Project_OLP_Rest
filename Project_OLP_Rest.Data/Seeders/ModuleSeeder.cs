using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    class ModuleSeeder : Seeder<Module>
    {
        public ModuleSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Module()
            {
                Name = "Module title",
                Description = "Module description",
            });

            _entities.Add(new Module()
            {
                Name = "Module title 2",
                Description = "Module description 2",
            });

            _context.SaveChanges();
        }
    }
}
