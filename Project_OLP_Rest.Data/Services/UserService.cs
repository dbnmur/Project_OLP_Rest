using Project_OLP_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_OLP_Rest.Data.Services
{
    class UserService : Service
    {
        protected UserService(OLP_Context context) : base(context)
        {
        }

        public void Add(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }
      
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(user => user.UserId == id);
        }
    }
}
