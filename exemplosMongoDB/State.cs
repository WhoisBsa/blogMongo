using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.GeoJsonObjectModel;

namespace exemplosMongoDB
{
    public class State
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public GeoJsonPolygon<GeoJson2DGeographicCoordinates> loc { get; set; }
    }
}
