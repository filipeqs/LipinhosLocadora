using Repository.Base;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class UserRepository : ReposityBase<User>
    {
        private readonly AppDbContext Context;

        public UserRepository(AppDbContext context) : base(context)
        {
            Context = context;
        }
            public User FindUser(string email, string password) => Context.Users.FirstOrDefault(u => 
                                                       u.Email == email & u.Password == password);
    }
}
