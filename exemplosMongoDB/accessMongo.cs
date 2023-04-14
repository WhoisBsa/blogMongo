using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class accessMongo
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var doc = new BsonDocument
            {
                { "Titulo", "Guerra dos Tronos" },
                { "Autor", "George R. R. Martin" },
                { "Ano", 1999 },
                { "Paginas", 856 },
                { "Assunto", new BsonArray { "Fantasia", "Ação" } }
            };

            Console.WriteLine(doc);

            //// aceso ao servidor do MOngoDB
            //string stringConection = "mongodb://localhost:27017";

            //IMongoClient client = new MongoClient(stringConection);

            //// acesso ao bd

            //IMongoDatabase mongoDatabase = client.GetDatabase("Library");

            //// acesso à coleção

            //IMongoCollection<BsonDocument> mongoCollection = mongoDatabase.GetCollection<BsonDocument>("Books");

            //// incluindo doc

            //await mongoCollection.InsertOneAsync(doc);

            //Console.WriteLine("Documento incluído");

            //var bsonFilter = Builders<BsonDocument>.Filter.Eq("Ano", 1999);

            //var a = await mongoCollection.Find(bsonFilter).ToListAsync();

            //Console.WriteLine(a[0]);
        }
    }
}
