using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public class ModuleService : GenericService<Module>, IModuleService
    {
        public ModuleService(OLP_Context context) : base(context) { }

        public IEnumerable<Module> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<Module> GetRecords(int moduleId)
        {
            throw new NotImplementedException();
        }
    }
}
