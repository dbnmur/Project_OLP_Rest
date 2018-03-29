using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;

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

                Assert.AreEqual(fecthedTeacher.FirstName, fecthedTeacher.FirstName);

                Domain.Course course = new Domain.Course()
                {
                    Name = "Test course name",
                    Description = "test course desc",
                    
                };

    

            }


        }
    }
}
