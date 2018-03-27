using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCore.Domain
{
    public class Record
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
