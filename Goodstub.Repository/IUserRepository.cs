using Goodstub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Repository
{
    /// <summary>
    /// User repository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns><see cref="IUser"/> object.</returns>
        IUser Get(string username);

        /// <summary>
        /// Validate the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool Validate(string email, string password);

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><see cref="IUser"/> object.</returns>
        IUser Insert(IUser user);
    }
}
