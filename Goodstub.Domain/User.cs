using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Domain
{
    public class User : IUser
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Firstname
        {
            get;
            set;
        }

        public string Lastname
        {
            get;
            set;
        }
    }
}
