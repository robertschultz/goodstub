using Goodstub.Data.Entity;
using Goodstub.Data.Repository;
using Goodstub.Service.Contract;
using Microsoft.Practices.Unity;
using Goodstub.Data.Interface;
using System.Collections.Generic;

namespace Goodstub.Service
{
    /// <summary>
    /// Service implementation for the <see cref="IUserService"/> interface.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Gets or sets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        [Dependency]
        public IUserRepository UserRepository { get; set; }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void CreateUser(IUser user)
        {
            UserRepository.CreateUser(user);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        public IList<IUser> GetAllUsers()
        {
            return UserRepository.GetAll();
        }

        /// <summary>
        /// Gets the <see cref="User"/> by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public IUser GetByUsername(string username)
        {
            return UserRepository.GetByUsername(username);
        }

        /// <summary>
        /// Gets the <see cref="User"/> by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public IUser GetByEmail(string email)
        {
            return UserRepository.GetByEmail(email);
        }
    }
}
