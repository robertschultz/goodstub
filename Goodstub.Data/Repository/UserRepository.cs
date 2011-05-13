using System.Collections.Generic;
using Goodstub.Data.Entity;
using NHibernate;
using Goodstub.Data.Interface;

namespace Goodstub.Data.Repository
{
    /// <summary>
    /// Repository class for the <see cref="User"/> contract.
    /// </summary>
    public class UserRepository : Repository<User>,  IUserRepository
    {
        /// <summary>
        /// Gets all <see cref="User"/> objects.
        /// </summary>
        /// <returns></returns>
        public IList<IUser> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>().List<IUser>();
            }
        }

        /// <summary>
        /// Gets the <see cref="User"/> by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public IUser GetByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>().Where(user => user.Email == username).SingleOrDefault();
            }
        }

        public IUser GetByEmail(string email)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>().Where(user => user.Email == email).SingleOrDefault();
            }
        }
        
        public bool CreateUser(IUser user)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    session.SaveOrUpdate(user);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
