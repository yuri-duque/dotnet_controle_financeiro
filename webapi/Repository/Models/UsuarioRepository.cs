using Domain.Models;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.Models
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(BaseContext ctx): base(ctx) { }

        public bool CheckUsername(string username)
        {
            return GetAll().Any(x => x.Username.ToLower().Equals(username.ToLower()));
        }

        public User FindUserByEmail(string email)
        {
            return GetAll().FirstOrDefault(x => x.Email.Equals(email));
        }

        public User FindUserByVerifyCode(string verifyCode)
        {
            return GetAll().FirstOrDefault(x => x.EmailVerifyCode.Equals(verifyCode));
        }
    }
}
