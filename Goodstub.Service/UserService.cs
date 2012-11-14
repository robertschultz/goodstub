using Goodstub.Domain;
using Goodstub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Service
{
    /// <summary>
    /// User service class.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository userRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="username">The email.</param>
        /// <returns>
        ///   <see cref="IUser" /> object.
        /// </returns>
        public IUser Get(string email)
        {
            return userRepository.Get(email);
        }

        /// <summary>
        /// Validates the specified user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Validate(string email, string password)
        {
            return userRepository.Validate(email, password);
        }

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <see cref="IUser" /> object.
        /// </returns>
        public IUser Insert(IUser user)
        {
            return userRepository.Insert(user);
        }
    }
}
