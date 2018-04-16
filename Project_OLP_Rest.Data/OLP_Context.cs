using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data
{
    public class OlpContext : DbContext
    {
        public OLP_Context() { }

        public OLP_Context(DbContextOptions<OLP_Context> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<ChatBot> ChatBots { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatBot>()
                .HasOne(p => p.Course)
                .WithOne(c => c.ChatBot)
                .HasForeignKey<Course>(c => c.ChatBotId);

            modelBuilder.Entity<TeacherCourse>()
                .HasKey(s => new { s.CourseId, s.TeacherId });

            modelBuilder.Entity<GroupCourse>()
                .HasKey(s => new { s.GroupId, s.CourseId });

            modelBuilder.Entity<Exercise>().HasBaseType<Record>();
        }
    }
}
