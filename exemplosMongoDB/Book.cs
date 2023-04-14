    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    public class Book
    {
        public Book(string Titulo, string Autor, int Ano, int Paginas, List<string> Assuntos)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Ano = Ano;
            this.Paginas = Paginas;
            this.Assuntos = Assuntos;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assuntos { get; set; }
    }
}

