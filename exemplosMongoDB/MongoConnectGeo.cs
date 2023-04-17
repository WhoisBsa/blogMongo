using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    public class MongoConnectGeo
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DB_NAME = "geo";
        public const string COLLECTION_NAME_AIRPORTS = "airports";
        public const string COLLECTION_NAME_STATES = "states";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoConnectGeo()
        {
            _client = new MongoClient(CONNECTION_STRING);

            _database = _client.GetDatabase(DB_NAME);
        }

        public IMongoClient Client { get { return _client; } }

        public IMongoDatabase Database { get { return _database; } }

        public IMongoCollection<Airport> Airports { 
            get {
                return _database.GetCollection<Airport>(COLLECTION_NAME_AIRPORTS);
            } 
        }

        public IMongoCollection<State> States
        {
            get
            {
                return _database.GetCollection<State>(COLLECTION_NAME_STATES);
            }
        }
    }
}
