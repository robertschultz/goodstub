using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Goodstub.Repository
{
    public class BaseRepository
    {
        private readonly MongoServer server = null;
        private readonly MongoDatabase database = null;

        public BaseRepository()
        {
            server = MongoServer.Create(ConfigurationManager.AppSettings["mongodb:Server"]);
            database = server.GetDatabase(ConfigurationManager.AppSettings["mongodb:Database"]);
        }

        public BaseRepository(MongoServer server, MongoDatabase database)
        {
            this.server = server;
            this.database = database;
        }

        public MongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
