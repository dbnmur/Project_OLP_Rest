﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class TeacherCourseTest
    {
        [TestMethod]
        [Ignore]
        public async System.Threading.Tasks.Task AddTeacher_ToCourse_TestAsync()
        {
            var options = new DbContextOptionsBuilder<OlpContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database_TeacherCourses")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OlpContext(options))
            {
                Teacher teacher = new Domain.Teacher()
                {
                    FirstName = "Test Name",
                    LastName = "Test last name",
                    Email = "test email",
                };

                var teacherService = new TeacherService(context);
                await teacherService.Create(teacher);

                Teacher fecthedTeacher = await teacherService.FindBy(x => x.FirstName == teacher.FirstName);

                Assert.AreEqual(fecthedTeacher.FirstName, teacher.FirstName);

                Course course = new Domain.Course()
                {
                    Name = "Test course name",
                    Description = "test course desc",
                };

                var courseService = new CourseService(context);
                await courseService.Create(course);

                Course fecthedCourse = await courseService.FindBy(x => x.Name == course.Name);

                Assert.AreEqual(fecthedCourse.Name, course.Name);

                //teacher.TeacherCourses.Add(course);
               
                TeacherCourse teacherCourse = new TeacherCourse()
                {
                    Course = course,
                    Teacher = teacher
                };

                context.Add(teacherCourse);
                context.SaveChanges();

                TeacherCourse fecthedTeacherCourse = context.TeacherCourses.FirstOrDefaultAsync().Result;

                Assert.AreEqual(fecthedTeacherCourse.Teacher.UserId, teacher.UserId);

                fecthedCourse = await courseService.FindBy(x => x.Name == course.Name);

                Assert.AreEqual(fecthedCourse.TeacherCourses.Count, 1);

                //Assert.AreEqual(teacher.TeacherCourses, teacherCourse.Course);
            }
        }
    }
}
