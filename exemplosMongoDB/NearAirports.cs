using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    internal class NearAirports
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var connection = new MongoConnectGeo();

            var point = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);

            var loc = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(point);

            var constructor = Builders<Airport>.Filter.NearSphere(x => x.loc, loc, 100000);

            var airportsList = await connection.Airports.Find(constructor).ToListAsync();

            foreach (var airport in airportsList)
            {
                Console.WriteLine(airport.name);
            }
        }
    }
}
