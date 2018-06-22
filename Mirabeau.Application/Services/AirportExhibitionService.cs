using Mirabeau.Domain;
using Mirabeau.Domain.Enums;
using Mirabeau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mirabeau.Application.Services
{
    public class AirportExhibitionService : IAirportExhibitionService
    {
        #region Private vars

        private readonly IAirportListService _airportListService;

        #endregion Private vars

        #region Ctors

        public AirportExhibitionService(IAirportListService airportListService)
        {
            _airportListService = airportListService;
        }

        #endregion Ctors

        #region Public methods

        public double CalculateDistanceBetweenAirports(Airport airport1, Airport airport2)
        {
            var lat1 = airport1.lat;

            var lat2 = airport2.lat;

            var lon1 = airport1.lon;

            var lon2 = airport2.lon;

            const int earthRadius = 6371;

            var dLat = ConvertDegreesToRadius(lat2 - lat1);

            var dLon = ConvertDegreesToRadius(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ConvertDegreesToRadius(lat1)) * Math.Cos(ConvertDegreesToRadius(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var kmDistance = earthRadius * c;

            return kmDistance;
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            var airports = _airportListService.GetAirportList();

            return airports;
        }

        public IEnumerable<Airport> GetEuropeanAirports()
        {
            var airports = GetAllAirports();

            var europeanAirports = airports.Where(x => x.continent == ContinentsEnum.EU.ToString());

            return europeanAirports;
        }

        #endregion Public methods

        #region Private methods

        private double ConvertDegreesToRadius(double degrees) => degrees * (Math.PI / 180);

        #endregion Private methods
    }
}