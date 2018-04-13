using System.Collections.Generic;

namespace Project_OLP_Rest.Domain
{
    public class RecordType : Entity
    {
        public int RecordTypeId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Record> Records { get; set; }
    }
}
