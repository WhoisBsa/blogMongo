﻿using Alura.GoogleMaps.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Alura.GoogleMaps.Web.Geocoding;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver;
using System.Web.Services.Description;

namespace Alura.GoogleMaps.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //coordenadas quaisquer para mostrar o mapa
            var coordenadas = new Coordenada("São Paulo", "-23.64340873969638", "-46.730219057147224");
            return View(coordenadas);
        }

        public async Task<JsonResult> Localizar(HomeViewModel model)
        {
            Debug.WriteLine(model);

            //Captura a posição atual e adiciona a lista de pontos
            Coordenada coordLocal = ObterCoordenadasDaLocalizacao(model.Endereco);
            var aeroportosProximos = new List<Coordenada>();
            aeroportosProximos.Add(coordLocal);

            //Captura a latitude e longitude locais
            double lat = Convert.ToDouble(coordLocal.Latitude.Replace(".", ","));
            double lon = Convert.ToDouble(coordLocal.Longitude.Replace(".", ","));

            //Testa o tipo de aeroporto que será usado na consulta
            string tipoAero = "";

            if (model.Tipo == TipoAeroporto.Internacionais)
            {
                tipoAero = "International";
            }
            if (model.Tipo == TipoAeroporto.Municipais)
            {
                tipoAero = "Municipal";
            }

            //Captura o valor da distancia
            int distancia = model.Distancia * 1000;

            //Conecta MongoDB    
            var connection = new conectandoMongoDBGeo();

            //Configura o ponto atual no mapa
            var point = new GeoJson2DGeographicCoordinates(lon, lat);

            var loc = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(point);

            // filtro
            var constructor = Builders<Aeroporto>.Filter;
            FilterDefinition<Aeroporto> filterBuilder = constructor.NearSphere(x => x.loc, loc, distancia);

            if (tipoAero.Length > 0)
            {
                filterBuilder &= constructor.Eq(x => x.type, tipoAero);
            }

            //Captura  a lista
            var airportsList = await connection.Airports.Find(filterBuilder).ToListAsync();

            //Escreve os pontos
            foreach (var airport in airportsList)
            {
                var coordinate = new Coordenada(
                    airport.name, 
                    Convert.ToString(airport.loc.Coordinates.Latitude).Replace(",", "."), 
                    Convert.ToString(airport.loc.Coordinates.Longitude).Replace(",", ".")
                );
                aeroportosProximos.Add(coordinate);
            }

            return Json(aeroportosProximos);
        }

        private Coordenada ObterCoordenadasDaLocalizacao(string endereco)
        {
            string url = $"http://maps.google.com/maps/api/geocode/json?address={endereco}";
            Debug.WriteLine(url);

            var coord = new Coordenada("Não Localizado", "-10", "-10");
            var response = new WebClient().DownloadString(url);
            var googleGeocode = JsonConvert.DeserializeObject<GoogleGeocodeResponse>(response);
            //Debug.WriteLine(googleGeocode);

            if (googleGeocode.status == "OK")
            {
                coord.Nome = googleGeocode.results[0].formatted_address;
                coord.Latitude = googleGeocode.results[0].geometry.location.lat;
                coord.Longitude = googleGeocode.results[0].geometry.location.lng;
            }

            return coord;
        }
    }
}