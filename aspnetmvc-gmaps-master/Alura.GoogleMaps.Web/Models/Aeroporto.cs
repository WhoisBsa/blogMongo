using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Alura.GoogleMaps.Web.Models
{
    public class Aeroporto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> loc { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string code { get; set; }
    }
}