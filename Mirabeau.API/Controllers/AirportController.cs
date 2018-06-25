using AutoMapper;
using Mirabeau.Domain;
using Mirabeau.Domain.Interfaces.Notifications;
using Mirabeau.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Mirabeau.API.Controllers
{
    [Authorize]
    public class AirportController : BaseApiController
    {
        #region Private vars

        private readonly IAirportExhibitionService _airportExhibitionService;

        #endregion Private vars

        #region Ctors

        public AirportController(IMapper mapper, IDomainNotificationHandler notification, IAirportExhibitionService airportExhibitionService)
            : base(mapper, notification)
        {
            _airportExhibitionService = airportExhibitionService;
        }

        #endregion Ctors

        public IEnumerable<Airport> Get()
        {
            var europeanAirports = _airportExhibitionService.GetEuropeanAirports();

            return europeanAirports;
        }
    }
}