using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class manipulandoDocs
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
                { "Titulo", "Guerra dos Tronos" }
            };

            doc.Add("Autor", "George R. R. Martin");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);
            var assuntos = new BsonArray();
            assuntos.Add("Fantasia");
            assuntos.Add("Ação");
            doc.Add("Assunto", assuntos);

            Console.WriteLine(doc);
        }
    }
}
