using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goodstub.Web.Models
{
    /// <summary>
    /// Sign up view model.
    /// </summary>
    public class SignUpModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required, MinLength(6)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>
        /// The firstname.
        /// </value>
        [Required]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>
        /// The lastname.
        /// </value>
        [Required]
        public string Lastname { get; set; }
    }
}