using AutoMapper;
using Mirabeau.Domain.Entities;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.UI.MVC.Models;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        #region Private vars

        private readonly ILoginService _loginService;

        #endregion Private vars

        #region Ctors

        public AccountController(IMapper mapper, ILoginService loginService)
           : base(mapper)
        {
            _loginService = loginService;
        }

        #endregion Ctors

        #region Actions

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            var user = _mapper.Map<User>(login);

            var loginValidated = _loginService.ValidateLogin(user);

            if (loginValidated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        #endregion Actions
    }
}