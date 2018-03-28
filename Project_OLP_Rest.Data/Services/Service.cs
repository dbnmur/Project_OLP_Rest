using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    public abstract class Service
    {
        private OLP_Context _context;

        protected Service(OLP_Context context)
        {
            _context = context;
        }
    }
}
