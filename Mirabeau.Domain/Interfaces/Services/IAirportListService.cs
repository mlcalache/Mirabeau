using System.Collections.Generic;

namespace Mirabeau.Domain.Interfaces.Services
{
    public interface IAirportListService
    {
        IEnumerable<Airport> GetAirportList();
    }
}