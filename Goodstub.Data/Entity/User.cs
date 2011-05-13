using Goodstub.Data.Interface;
using System.Runtime.Serialization;

namespace Goodstub.Data.Entity
{
    /// <summary>
    /// User entity class.
    /// </summary>
    [DataContract]
    public class User : IUser
    {
        /// <summary>
        /// Gets the user id.
        /// </summary>
        [DataMember]
        public virtual long UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [DataMember]
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember]
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt.
        /// </value>
        [DataMember]
        public virtual string Salt { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>
        /// The firstname.
        /// </value>
        [DataMember]
        public virtual string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>
        /// The lastname.
        /// </value>
        [DataMember]
        public virtual string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the user role id.
        /// </summary>
        /// <value>
        /// The user role id.
        /// </value>
        [DataMember]
        public virtual short UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is enabled.
        /// </summary>
        /// <value>
        /// true if enabled; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is registered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if registered; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public virtual bool Registered { get; set; }

        /// <summary>
        /// Gets or sets the registration key.
        /// </summary>
        /// <value>
        /// The registration key.
        /// </value>
        [DataMember]
        public virtual string RegistrationKey { get; set; }
    }
}
