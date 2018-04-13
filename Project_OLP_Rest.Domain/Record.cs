using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class Record : Entity
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public int RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }
    }

    public class Exercise : Record
    {
        public string AnswerRegex { get; set; }
        public bool IsCompleted { get; set; }
    }
}
