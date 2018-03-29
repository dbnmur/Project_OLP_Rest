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
        public void UserGroupTest()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
            .UseInMemoryDatabase(databaseName: "UserGroupTest")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OLP_Context(options))
            {
                Domain.Group group = new Domain.Group()
                {
                    Name = "Test1",
                    Description = "test desc1"
                };

                var service = new GroupService(context);
                service.Create(group);

                Domain.Group fecthedGroup = service.FindBy(x => x.Name == group.Name);
                Assert.AreEqual(fecthedGroup.Name, group.Name);
                Console.Write("Group was : " + group.Name + " successfully added");

                //user insert
                Domain.Student student = new Domain.Student()
                {
                    FirstName = "Daniel",
                    LastName = "Zeimo",
                    Email = "cccp@cc.cc",


                };

                var service1 = new UserService(context);
                service1.Create(student);

                Domain.User fetchedUser = service1.FindBy(x => x.FirstName == student.FirstName);
                Assert.AreEqual(fetchedUser.FirstName, student.FirstName);

                Console.Write("User was : " + student.FirstName + " successfully added");



            }
        }



        }
}
