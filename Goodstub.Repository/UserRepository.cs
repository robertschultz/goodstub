using Goodstub.Domain;
using MongoDB.Driver.Linq;
using System;
using System.Configuration;
using System.Linq;
using Hash = Goodstub.Common.Encryption.Hash;

namespace Goodstub.Repository
{
    /// <summary>
    /// User repository class.
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        ///   <see cref="IUser" /> object.
        /// </returns>
        public IUser Get(string email)
        {
            var collection = base.GetDatabase().GetCollection<User>("user");
            var user = collection.AsQueryable<User>().FirstOrDefault(x => x.Email == email);

            return user;
        }

        /// <summary>
        /// Validate the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Validate(string email, string password)
        {
            var collection = base.GetDatabase().GetCollection<User>("user");
            var user = collection.AsQueryable<User>().FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                if (Hash.VerifyHash(password, ConfigurationManager.AppSettings["app:HashAlgorithm"], user.Password))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <see cref="IUser" /> object.
        /// </returns>
        public IUser Insert(IUser user)
        {
            if (Get(user.Email) != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            var collection = base.GetDatabase().GetCollection<User>("user");

            // Generate a hash.
            var hash = Hash.ComputeHash(user.Password, ConfigurationManager.AppSettings["app:HashAlgorithm"], null);

            // Set the password to the new hash value.
            user.Password = hash;

            collection.Insert(user);

            return user;
        }
    }
}
