using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class ClassManipulationOut
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var connection = new MongoConnect();

            Book book = new Book(
                "Dom Casmurro",
                "Machado de Assis",
                1923,
                188,
                new List<string> { "Romance", "Literatura Brasileira" }
            );

            await connection.Books.InsertOneAsync(book);

            book = new Book(
                "A Arte da Ficção",
                "David Lodge",
                2002,
                230,
                new List<string> { "Didático", "Autoajuda" }
            );

            await connection.Books.InsertOneAsync(book);
        }
    }
}
