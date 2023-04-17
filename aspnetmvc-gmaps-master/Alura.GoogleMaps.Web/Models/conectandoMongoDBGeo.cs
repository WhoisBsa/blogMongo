using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;


namespace Alura.GoogleMaps.Web.Models
{
    public class conectandoMongoDBGeo
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DB_NAME = "geo";
        public const string COLLECTION_NAME_AIRPORTS = "airports";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static conectandoMongoDBGeo()
        {
            _client = new MongoClient(CONNECTION_STRING);

            _database = _client.GetDatabase(DB_NAME);
        }

        public IMongoClient Client { get { return _client; } }

        public IMongoDatabase Database { get { return _database; } }

        public IMongoCollection<Aeroporto> Airports
        {
            get
            {
                return _database.GetCollection<Aeroporto>(COLLECTION_NAME_AIRPORTS);
            }
        }
    }
}