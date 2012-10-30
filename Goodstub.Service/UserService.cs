using Goodstub.Domain;
using Goodstub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository = null;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IUser Get(string username)
        {
            return userRepository.Get(username);
        }

        public IUser Insert(IUser user)
        {
            return userRepository.Insert(user);
        }
    }
}
