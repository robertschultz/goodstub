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
    /// <summary>
    /// Base repository class which instantiates all of the Mongo specific settings.
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// The Mongo server.
        /// </summary>
        private readonly MongoServer server = null;

        /// <summary>
        /// The Mongo database.
        /// </summary>
        private readonly MongoDatabase database = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository" /> class.
        /// </summary>
        public BaseRepository()
        {
            server = MongoServer.Create(ConfigurationManager.AppSettings["mongodb:Server"]);
            database = server.GetDatabase(ConfigurationManager.AppSettings["mongodb:Database"]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository" /> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="database">The database.</param>
        public BaseRepository(MongoServer server, MongoDatabase database)
        {
            this.server = server;
            this.database = database;
        }

        /// <summary>
        /// Gets the database object.
        /// </summary>
        /// <returns></returns>
        public MongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
