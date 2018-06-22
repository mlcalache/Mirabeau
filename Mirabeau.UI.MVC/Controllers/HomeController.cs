using AutoMapper;
using Mirabeau.Domain.Interfaces.Services;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC.Controllers
{
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

        #region Actions

        public ActionResult Index()
        {
            return View();
        }

        #endregion Actions
    }
}