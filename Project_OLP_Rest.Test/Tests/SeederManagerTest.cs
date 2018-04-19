using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Seeders;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class SeederManagerTest
    {
        [TestMethod]
        public void SeederManagerRunTest()
        {
            var options = new DbContextOptionsBuilder<OlpContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database_SeederManager")
                .Options;

            using (var context = new OlpContext(options))
            {
                var SeederManager = new SeederManager(context);
            }
        }
    }
}
