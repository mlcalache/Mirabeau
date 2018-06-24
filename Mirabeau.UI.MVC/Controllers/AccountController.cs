using AutoMapper;
using Mirabeau.Domain.Entities;
using Mirabeau.Domain.Interfaces.Notifications;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.UI.MVC.Models;
using Newtonsoft.Json;
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

        public AccountController(IMapper mapper, IDomainNotificationHandler notification, ILoginService loginService)
           : base(mapper, notification)
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
        public ActionResult Login(LoginViewModel login)
        {
            var user = _mapper.Map<User>(login);

            var loginValidated = _loginService.ValidateLogin(user);

            if (loginValidated)
            {
                SetUserCookie(login.Username);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            RemoveCookies(USERCOOKIE);

            return RedirectToAction("Index");
        }

        private void SetUserCookie(string username)
        {
            var userCookie = CreateCookie(USERCOOKIE, JsonConvert.SerializeObject(username), CookieExpirationInMinutes);
        }

        #endregion Actions
    }
}