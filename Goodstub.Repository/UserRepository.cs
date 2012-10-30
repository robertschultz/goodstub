using Goodstub.Domain;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Goodstub.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public IUser Get(string username)
        {
            var collection = base.GetDatabase().GetCollection<User>("user");
            var user = collection.AsQueryable<User>().FirstOrDefault(x => x.Username == username);

            return user;
        }

        public IUser Insert(IUser user)
        {
            var collection = base.GetDatabase().GetCollection<User>("user");

            collection.Insert(user);
            
            return user;
        }
    }
}
