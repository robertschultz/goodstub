using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Domain
{
    /// <summary>
    /// User interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [BsonId]
        ObjectId Id { get; set; }

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
    }
}
