using System.Collections.Generic;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IRecordService : IGenericService<Record>
    {
        IEnumerable<Record> GetAll();
    }
}
