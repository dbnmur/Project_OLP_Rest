using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public abstract class Service
    {
        protected OlpContext _context;

        protected Service(OlpContext context)
        {
            _context = context;
        }
    }
}
