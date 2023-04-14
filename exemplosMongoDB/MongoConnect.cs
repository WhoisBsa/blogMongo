using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    public class MongoConnect
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DB_NAME = "Library";
        public const string COLLECTION_NAME = "Books";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoConnect()
        {
            _client = new MongoClient(CONNECTION_STRING);

            _database = _client.GetDatabase(DB_NAME);
        }

        public IMongoClient Client { get { return _client; } }

        public IMongoDatabase Database { get { return _database; } }

        public IMongoCollection<Book> Books { 
            get {
                return _database.GetCollection<Book>(COLLECTION_NAME);
            } 
        }
    }
}
