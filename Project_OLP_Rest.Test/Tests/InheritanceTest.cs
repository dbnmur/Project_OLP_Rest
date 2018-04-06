using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class InheritanceTest
    {


        [TestMethod]
        public void InheritanceTesti()
        {

            var options = new DbContextOptionsBuilder<OLP_Context>()
                .UseInMemoryDatabase(databaseName: "InheritanceTest")
                .Options;

            using (var context = new OLP_Context(options))
            {
                //stud 1
                Domain.Student student = new Domain.Student()
                {
                    FirstName = "Daniel",
                    LastName = "Zeimo",
                    Email = "cccp@cc.cc",
                };

                var studentService = new UserService(context);
                studentService.Create(student);

                Domain.User fetchedUser = studentService.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);
                Console.Write("Stud inserted");
                //stud 2
                Domain.Student student2 = new Domain.Student()
                {
                    FirstName = "Lukas",
                    LastName = "Velycka",
                    Email = "cccp@cc.cc",
                };

                var student1Service = new UserService(context);
                student1Service.Create(student2);

                Domain.User fetchedUser2 = student1Service.FindBy(x => x.FirstName == student2.FirstName);
                Assert.AreEqual(fetchedUser2.FirstName, student2.FirstName);
                Console.Write("Stud 2 inserted");
                //stud 3
                Domain.Student student3 = new Domain.Student()
                {
                    FirstName = "Airidas",
                    LastName = "Amsejus",
                    Email = "cccp@cc.cc",
                };

                var student2Service = new UserService(context);
                student2Service.Create(student3);

                Domain.User fetchedUser3 = student2Service.FindBy(x => x.FirstName == student3.FirstName);
                Assert.AreEqual(fetchedUser3.FirstName, student3.FirstName);
                Console.Write("Stud 3 inserted");

                //teach 1
                Domain.Teacher teacher = new Domain.Teacher()
                {
                    FirstName = "Nerijus",
                    LastName = "Muranovas",
                    Email = "cccp@cc.cc",
                };

                var teacherService = new TeacherService(context);
                teacherService.Create(teacher);

                Domain.Teacher fetchedTeacher = teacherService.FindBy(x => x.FirstName == teacher.FirstName);
                Assert.AreEqual(teacher.FirstName, teacher.FirstName);

                Console.Write("Teacher inserted");

                //StudentService studentServiceF = new StudentService

            }

        }

    }
}
