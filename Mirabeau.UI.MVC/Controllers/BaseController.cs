using AutoMapper;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        #region Protected vars

        protected readonly IMapper _mapper;

        #endregion Protected vars

        #region Ctors

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion Ctors
    }
}