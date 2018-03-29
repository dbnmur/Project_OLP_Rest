using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    class RecordSeeder : Seeder<Record>
    {
        public RecordSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Record()
            {
                Name = "Record name",
                Description = "Record description",
                Url = "Record url",
            });

            _entities.Add(new Record()
            {
                Name = "Record name 2",
                Description = "Record description 2",
                Url = "Record url 2",
            });

            _context.SaveChanges();
        }
    }
}
