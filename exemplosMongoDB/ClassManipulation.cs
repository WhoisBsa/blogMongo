using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class ClassManipulation
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            string conection = "mongodb://localhost:27017";

            IMongoClient client = new MongoClient(conection);

            IMongoDatabase db = client.GetDatabase("Library");

            IMongoCollection<Book> collection = db.GetCollection<Book>("Books");


            Book book = new Book(
                "Sob a redoma",
                "Stephan King",
                2012,
                679,
                new List<string> { "Ficção Científica", "Terror", "Ação" }
            );

            await collection.InsertOneAsync(book);
        }
    }
}
