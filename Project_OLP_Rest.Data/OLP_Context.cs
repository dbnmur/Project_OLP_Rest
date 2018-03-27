using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data
{
    public class OLP_Context : DbContext
    {


        public OLP_Context (DbContextOptions<OLP_Context> options) : base (options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Group> Groups { get; set; }      
        public DbSet<Record> Records { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<TeacherCourse)
        //        .HasKey(t => new {});

        //    builder.Entity<GroupCourse)
        //        .HasKey(t => new { t.TeamId, t.UserId });

            
        //}



    }
}
