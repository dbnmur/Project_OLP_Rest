using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Test
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public async Task GroupAddTestAsync()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database_ADD")
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
                await service.Create(group);

                Domain.Group fecthedGroup = await service.FindBy(x => x.Name == group.Name);
                Assert.AreEqual(fecthedGroup.Name, group.Name);
                Console.Write("Group was : " + group.Name + " successfully added");
            }
        }
    }
}
