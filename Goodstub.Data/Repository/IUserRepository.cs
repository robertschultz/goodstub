using System.Collections.Generic;
using Goodstub.Data.Entity;
using Goodstub.Data.Interface;

namespace Goodstub.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IList<IUser> GetAll();
        bool CreateUser(IUser user);
        IUser GetByUsername(string username);
        IUser GetByEmail(string email);
    }
}
