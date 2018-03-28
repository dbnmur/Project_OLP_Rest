﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data
{
    public class OLP_Context : DbContext
    {
        public OLP_Context()
        {

        }

        public OLP_Context (DbContextOptions<OLP_Context> options) : base (options)
        {

        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Group> Groups { get; set; }      
        public DbSet<Record> Records { get; set; }
        public object Teacher { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(s => new { s.CourseId, s.TeacherId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GroupCourse>()
                .HasKey(s => new { s.GroupId, s.CourseId });
            base.OnModelCreating(modelBuilder);

        }



    }
}
