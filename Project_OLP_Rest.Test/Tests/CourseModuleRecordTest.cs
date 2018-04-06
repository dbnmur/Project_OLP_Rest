using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class CourseModuleRecordTest
    {

        [TestMethod]
        public void AddModuleToCourse()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
            .UseInMemoryDatabase(databaseName: "CourseModuleTest")
             .Options;
            // Run the test against one instance of the context
            using (var context = new OLP_Context(options))
            {
                Domain.Course course = new Domain.Course()
                {
                    CourseId = 1,
                    Name = "PSI",
                    Description = "make viko great again"

                };

                var courseService = new CourseService(context);
                courseService.Create(course);

                Domain.Course fecthedCourse = courseService.FindBy(x => x.Name == course.Name);
                Assert.AreEqual(fecthedCourse.Name, course.Name);
                Console.Write("|Group  : " + course.Name + " successfully added");
                //insert module
                Domain.Module module = new Domain.Module()
                {
                    Name = "TestModule",
                    ModuleId = 1,
                    CourseId = 1
                };

                var moduleService = new ModuleService(context);
                moduleService.Create(module);

                Domain.Module fetchedModule = moduleService.FindBy(x => x.Name == module.Name);
                Assert.AreEqual(fetchedModule.Name, module.Name);
                Assert.AreEqual(course.Name, fetchedModule.Course.Name);

                
                //insert record
                Domain.Record record = new Domain.Record()
                {
                    Name = "TestRecord",
                    ModuleId = 1,
                    RecordId = 1
                };

                var recordService = new RecordService(context);
                recordService.Create(record);

                Domain.Record fetchedRecord = recordService.FindBy(x => x.Name == record.Name);
                Assert.AreEqual(fetchedRecord.Name, record.Name);

                Assert.AreEqual(course.Name, fetchedRecord.Module.Course.Name);

                Console.Write("|Course Name  : " + course.Name + " Course name through record "+ fetchedRecord.Module.Course.Name);

            }
        }
    }
}
