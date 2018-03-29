using System;
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
        public void AddTeacher_ToCourse_Test()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database_TeacherCourses")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OLP_Context(options))
            {
                Domain.Teacher teacher = new Domain.Teacher()
                {
                    FirstName = "Test Name",
                    LastName = "Test last name",
                    Email = "test email",
                    
                };

                var teacherService = new TeacherService(context);
                teacherService.Create(teacher);


                Domain.Teacher fecthedTeacher = teacherService.FindBy(x => x.FirstName == teacher.FirstName);

                Assert.AreEqual(fecthedTeacher.FirstName, teacher.FirstName);

                Domain.Course course = new Domain.Course()
                {
                    Name = "Test course name",
                    Description = "test course desc",
                };

                var courseService = new CourseService(context);
                courseService.Create(course);


                Domain.Course fecthedCourse = courseService.FindBy(x => x.Name == course.Name);

                Assert.AreEqual(fecthedCourse.Name, course.Name);

                //teacher.TeacherCourses.Add(course);
               
                TeacherCourse teacherCourse = new TeacherCourse()
                {
                    Course = course,
                    Teacher = teacher
                };

                context.Add(teacherCourse);
                context.SaveChanges();

                Domain.TeacherCourse fethedTeacherCourse = context.TeacherCourses.Find();

                Assert.AreEqual(fethedTeacherCourse.Teacher, teacher);

                Assert.AreEqual(teacherCourse.Teacher, teacher);
                Assert.AreEqual(teacherCourse.Course, course);

                //Assert.AreEqual(teacher.TeacherCourses, teacherCourse.Course);


            }


        }
    }
}
