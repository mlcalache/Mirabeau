using AutoMapper;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.UI.MVC.Models;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Private vars

        private readonly IAirportExhibitionService _airportExhibitionService;

        #endregion Private vars

        #region Ctors

        public HomeController(IMapper mapper, IAirportExhibitionService airportExhibitionService)
            : base(mapper)
        {
            _airportExhibitionService = airportExhibitionService;
        }

        #endregion Ctors

        #region MVC Actions

        public ActionResult Index()
        {
            return View();
        }

        #endregion MVC Actions

        #region AJAX Actions

        public ActionResult GetEuropeanAirports()
        {
            var europeanAirports = _airportExhibitionService.GetEuropeanAirports();

            var europeanAirportsViewModel = _mapper.Map<AirportViewModel>(europeanAirports);

            return Json(new { airports = europeanAirportsViewModel }, JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}