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
        public async Task UserAddTestAsync()
        {
            var options = new DbContextOptionsBuilder<OlpContext>()
                .UseInMemoryDatabase(databaseName: "UserAddTest")
                .Options;

            using (var context = new OlpContext(options))
            {
                Domain.Student student = new Domain.Student()
                {
                    FirstName = "Daniel",
                    LastName = "Zeimo",
                    Email = "cccp@cc.cc",
                };

                var service = new UserService(context);
                await service.Create(student);

                Domain.User fetchedUser = await service.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);

                Console.Write("User was : " + student.FirstName + " successfully added");
            }
        }
        [TestMethod]
        public async Task OneToManyStudentGroupTestAsync()
        {
            var options = new DbContextOptionsBuilder<OlpContext>()
            .UseInMemoryDatabase(databaseName: "UserGroupTest")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OlpContext(options))
            {
                Domain.Group group = new Domain.Group()
                {
                    GroupId = 1,
                    Name = "PI15B",
                    Description = "make viko great again"  
                };

                var groupService = new GroupService(context);
                await groupService.Create(group);

                Domain.Group fecthedGroup = await groupService.FindBy(x => x.Name == group.Name);
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
                await studentService.Create(student);

                Domain.Student fetchedUser = await studentService.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);
                Assert.AreEqual(group.Name, fetchedUser.Group.Name);
                Console.Write("|User  : " + student.FirstName + " successfully added");
                Console.Write("|User group : " + fetchedUser.Group.Name  +" Description"+ fetchedUser.Group.Description);
            }
        }



        }
}
