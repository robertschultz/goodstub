using Goodstub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Repository
{
    public interface IUserRepository
    {
        IUser Get(string username);
        IUser Insert(IUser user);
    }
}
