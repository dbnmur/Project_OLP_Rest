using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    public abstract class Seeder<T> where T : Entity
    {
        protected OLP_Context _context;
        protected DbSet<T> _entities;

        public Seeder(OLP_Context context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public abstract void Run();
    }
}
