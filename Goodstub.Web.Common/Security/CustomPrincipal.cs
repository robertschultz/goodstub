using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Web.Common.Security
{
    /// <summary>
    /// Custom principal to handle user fields.
    /// </summary>
    public class CustomPrincipal : IPrincipal
    {
        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        public bool IsInRole(string role) { return false; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>
        /// The firstname.
        /// </value>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>
        /// The lastname.
        /// </value>
        public string Lastname { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPrincipal" /> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }
    }
}
