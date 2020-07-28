using Domain.Models;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.ModelsRepository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(BaseContext ctx): base(ctx) { }

        public bool CheckUsername(string username)
        {
            return GetAll().Any(x => x.Username.ToLower().Equals(username.ToLower()));
        }
    }
}
