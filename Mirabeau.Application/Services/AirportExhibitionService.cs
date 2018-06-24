using Mirabeau.Domain;
using Mirabeau.Domain.DTOs;
using Mirabeau.Domain.Enums;
using Mirabeau.Domain.Interfaces.Notifications;
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

        #region Protected vars

        protected readonly IDomainNotificationHandler _notification;

        #endregion Protected vars

        #region Ctors

        public AirportExhibitionService(IAirportListService airportListService, IDomainNotificationHandler notification)
        {
            _airportListService = airportListService;
            _notification = notification;
        }

        #endregion Ctors

        #region Public methods

        public Airport GetAirport(string IATA)
        {
            return GetAllAirports().FirstOrDefault(x => !string.IsNullOrEmpty(x.iata) && x.iata.ToUpper() == IATA.ToUpper());
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

        public IEnumerable<Airport> GetEuropeanAirports(AirportFilterDTO filters)
        {
            var airports = GetAllAirports();

            var europeanAirports = airports.Where(x => x.continent == ContinentsEnum.EU.ToString());

            if (filters != null)
            {
                if (!string.IsNullOrEmpty(filters.IATA))
                {
                    europeanAirports = europeanAirports.Where(x => !string.IsNullOrEmpty(x.iata) && x.iata.ToUpper().Contains(filters.IATA.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filters.ISO))
                {
                    europeanAirports = europeanAirports.Where(x => !string.IsNullOrEmpty(x.iso) && x.iso.ToUpper().Contains(filters.ISO.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filters.Name))
                {
                    europeanAirports = europeanAirports.Where(x => !string.IsNullOrEmpty(x.name) && x.name.ToUpper().Contains(filters.Name.ToUpper()));
                }
            }

            return europeanAirports;
        }

        public DistanceResultDTO GetDistance(string iata1, string iata2)
        {
            var distanceResult = new DistanceResultDTO
            {
                Distance = 0
            };

            if (!string.IsNullOrEmpty(iata1) && !string.IsNullOrEmpty(iata2))
            {
                var airport1 = GetAirport(iata1);

                if (airport1.lat == 0)
                {
                    _notification.Add($"Airport {airport1.iata} has no latitude defined.");
                }

                if (airport1.lon == 0)
                {
                    _notification.Add($"Airport {airport1.iata} has no longitude defined.");
                }

                if (!_notification.HasNotifications)
                {
                    var airport2 = GetAirport(iata2);

                    if (airport2.lat == 0)
                    {
                        _notification.Add($"Airport {airport2.iata} has no latitude defined.");
                    }

                    if (airport2.lon == 0)
                    {
                        _notification.Add($"Airport {airport2.iata} has no longitude defined.");
                    }

                    if (!_notification.HasNotifications)
                    {
                        distanceResult.Distance = CalculateDistanceBetweenAirports(airport1, airport2);
                    }
                }
            }
            else
            {
                _notification.Add("Both airport iata codes must be informed");
            }

            return distanceResult;
        }

        #endregion Public methods

        #region Private methods

        private double CalculateDistanceBetweenAirports(Airport airport1, Airport airport2)
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

        private double ConvertDegreesToRadius(double degrees) => degrees * (Math.PI / 180);

        #endregion Private methods
    }
}