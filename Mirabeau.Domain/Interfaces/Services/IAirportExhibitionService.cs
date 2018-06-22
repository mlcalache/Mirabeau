using System.Collections.Generic;

namespace Mirabeau.Domain.Interfaces.Services
{
    public interface IAirportExhibitionService
    {
        double CalculateDistanceBetweenAirports(Airport airport1, Airport airport2);

        IEnumerable<Airport> GetAllAirports();

        IEnumerable<Airport> GetEuropeanAirports();
    }
}