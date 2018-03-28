using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Response
{
    public class UnderstandableResponse
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string[] Messages { get; set; }
        public object Result { get; set; }
    }
}
