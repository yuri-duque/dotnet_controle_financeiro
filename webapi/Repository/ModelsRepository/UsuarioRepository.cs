using Domain.Models;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.ModelsRepository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(BaseContext ctx): base(ctx) { }

        public bool CheckUsername(string username)
        {
            return GetAll().Any(x => x.Username.ToLower().Equals(username.ToLower()));
        }
    }
}
