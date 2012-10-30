using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodstub.Domain
{
    public interface IUser
    {
        [BsonId]
        ObjectId Id { get; set; }
        string Username { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
    }
}
