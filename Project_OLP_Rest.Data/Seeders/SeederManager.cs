using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Seeders
{
    public class SeederManager
    {
        protected List<Entity> _entitiesData;
        private List<Seeder<Entity>> _seeders;

        public SeederManager(OlpContext context)
        {
            // Add all seeders here
            new GroupSeeder(context).Run();
            new CourseSeeder(context).Run();
            new ModuleSeeder(context).Run();
            new RecordSeeder(context).Run();
            new StudentSeeder(context).Run();
            new TeacherSeeder(context).Run();
        }
    }
}
