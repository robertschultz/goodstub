using Goodstub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Service
{
    /// <summary>
    /// User service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="username">The email.</param>
        /// <returns><see cref="IUser"/> object.</returns>
        IUser Get(string email);

        /// <summary>
        /// Validates the specified user.
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
