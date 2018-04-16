using System.Collections.Generic;
using System.Threading.Tasks;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Data.Interfaces
{
    public interface IRecordService : IGenericService<Record>
    {
        Task<IEnumerable<Record>> GetAll();
    }
}
