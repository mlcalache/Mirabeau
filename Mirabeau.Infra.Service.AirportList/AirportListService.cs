using Mirabeau.Domain;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.Infra.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mirabeau.Infra.Service.AirportList
{
    public class AirportListService : IAirportListService
    {
        public IEnumerable<Airport> GetAirportList()
        {
            string res;
            var url = ConfigurationManagerHelper.UrlJsonAirport;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/").Result;
                res = string.Empty;
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();
                    res = result.Result;
                }
            }

            return new List<Airport>();
        }
    }
}