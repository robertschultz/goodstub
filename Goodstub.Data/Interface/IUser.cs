using System.Runtime.Serialization;
using Goodstub.Data.Entity;

namespace Goodstub.Data.Interface
{
    public interface IUser
    {
        /// <summary>
        /// Gets the user id.
        /// </summary>
        long UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt.
        /// </value>
        string Salt { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>
        /// The firstname.
        /// </value>
        string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>
        /// The lastname.
        /// </value>
        string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the user role id.
        /// </summary>
        /// <value>
        /// The user role id.
        /// </value>
        short UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is enabled.
        /// </summary>
        /// <value>
        /// true if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IUser"/> is registered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if registered; otherwise, <c>false</c>.
        /// </value>
        bool Registered { get; set; }

        /// <summary>
        /// Gets or sets the registration key.
        /// </summary>
        /// <value>
        /// The registration key.
        /// </value>
        string RegistrationKey { get; set; }
    }
}
