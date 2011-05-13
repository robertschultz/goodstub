using FluentNHibernate.Mapping;
using Goodstub.Data.Entity;

namespace Goodstub.Data.Mapping
{
    /// <summary>
    /// Performs mapping for the <see cref="User"/> class.
    /// </summary>
    public class UserMap : ClassMap<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMap"/> class.
        /// </summary>
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Email);
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Salt);
            Map(x => x.Firstname);
            Map(x => x.Lastname);
            Map(x => x.UserRoleId);
            Map(x => x.Enabled);
            Map(x => x.Registered);
            Map(x => x.RegistrationKey);
        }
    }
}
