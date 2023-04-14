using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class BookList
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            try
            {
                var connection = new MongoConnect();

                var books = await connection.Books.Find(new BsonDocument()).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nFiltrado\n\n\n");

                var filter = Builders<Book>.Filter.Eq("Autor", "Machado de Assis");
               
                books = await connection.Books.Find(filter).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nFiltrado\n\n\n");

                filter = Builders<Book>.Filter.Eq(x => x.Autor, "Machado de Assis");

                books = await connection.Books.Find(filter).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }


                Console.WriteLine("\n\n\nFiltrado\n\n\n");

                filter = Builders<Book>.Filter.Gte(x => x.Ano, 1999);

                books = await connection.Books.Find(filter).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nFiltrado\n\n\n");

                filter = Builders<Book>.Filter.Gte(x => x.Ano, 1999) & Builders<Book>.Filter.Gte(x => x.Paginas, 300);

                books = await connection.Books.Find(filter).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nFiltrado\n\n\n");

                filter = Builders<Book>.Filter.AnyEq(x => x.Assuntos, "Autoajuda");

                books = await connection.Books.Find(filter).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nLimitado\n\n\n");

                filter = Builders<Book>.Filter.Gte(x => x.Paginas, 300); ;

                books = await connection.Books.Find(filter).SortBy(x => x.Titulo).ToListAsync();

                foreach (var book in books)
                {
                    Console.WriteLine(book.ToJson<Book>());
                }


                Console.WriteLine("\n\n\nEditando\n\n\n");

                filter = Builders<Book>.Filter.Eq("Autor", "Machado de Assis");

                books = await connection.Books.Find(filter).ToListAsync();  

                foreach (var book in books)
                {
                    book.Ano = 1929;
                    book.Paginas = 190;

                    await connection.Books.ReplaceOneAsync(filter, book);
                    Console.WriteLine(book.ToJson<Book>());
                }

                Console.WriteLine("\n\n\nEditando Muitos\n\n\n");


                filter = Builders<Book>.Filter.Gte(x => x.Paginas, 300);

                var updFilter = Builders<Book>.Update.Set(x => x.Ano, new Random().Next(1900, 2010));

                await connection.Books.UpdateManyAsync(filter, updFilter);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
