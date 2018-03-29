using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    class StudentSeeder : Seeder<Student>
    {
        public StudentSeeder(OLP_Context context) : base(context) { }

        public override void Run()
        {
            _entities.Add(new Student()
            {
                FirstName = "Jonas",
                LastName = "Jonaitis",
                Email = "jonas@jonaitis.com",
            });

            _entities.Add(new Student()
            {
                FirstName = "Petras",
                LastName = "Petraitis",
                Email = "petras@petraitis.com",
            });

            _context.SaveChanges();
        }
    }
}
