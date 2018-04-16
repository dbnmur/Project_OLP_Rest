using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Data.Services
{
    public class RecordService : GenericService<Record>, IRecordService
    {
        public RecordService(OLP_Context context) : base(context) { }

        public async Task<IEnumerable<Record>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
