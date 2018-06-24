using Mirabeau.Domain.DTOs;
using System.Collections.Generic;

namespace Mirabeau.Domain.Interfaces.Services
{
    public interface IAirportExhibitionService
    {
        Airport GetAirport(string IATA);

        IEnumerable<Airport> GetAllAirports();

        DistanceResultDTO GetDistance(string iata1, string iata2);

        IEnumerable<Airport> GetEuropeanAirports();

        IEnumerable<Airport> GetEuropeanAirports(AirportFilterDTO filters);
    }
}