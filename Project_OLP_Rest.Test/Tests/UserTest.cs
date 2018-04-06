using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserAddTest()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
                .UseInMemoryDatabase(databaseName: "UserAddTest")
                .Options;

            using (var context = new OLP_Context(options))
            {
                Domain.Student student = new Domain.Student()
                {
                    FirstName = "Daniel",
                    LastName = "Zeimo",
                    Email = "cccp@cc.cc",
                };

                var service = new UserService(context);
                service.Create(student);

                Domain.User fetchedUser = service.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);

                Console.Write("User was : " + student.FirstName + " successfully added");
            }
        }
        [TestMethod]
        public void OneToManyStudentGroupTest()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
            .UseInMemoryDatabase(databaseName: "UserGroupTest")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OLP_Context(options))
            {
                Domain.Group group = new Domain.Group()
                {
                    GroupId = 1,
                    Name = "PI15B",
                    Description = "make viko great again"  
                };

                var groupService = new GroupService(context);
                groupService.Create(group);

                Domain.Group fecthedGroup = groupService.FindBy(x => x.Name == group.Name);
                Assert.AreEqual(fecthedGroup.Name, group.Name);
                Console.Write("Group  : " + group.Name + " successfully added");
                
                //user insert
                Domain.Student student = new Domain.Student()
                {
                    GroupId = 1,
                    FirstName = "Daniel",
                    LastName = "Zeimo",
                    Email = "cccp@cc.cc"

                };

                var studentService = new StudentService(context);
                studentService.Create(student);

                Domain.Student fetchedUser = studentService.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);
                Assert.AreEqual(group.Name, fetchedUser.Group.Name);
                Console.Write("|User  : " + student.FirstName + " successfully added");
                Console.Write("|User group : " + fetchedUser.Group.Name  +" Description"+ fetchedUser.Group.Description);
            }
        }



        }
}
