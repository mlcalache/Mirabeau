using AutoMapper;
using Mirabeau.Infra.CrossCutting.Helpers;
using System;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mirabeau.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        #region Protected consts

        protected const string USERCOOKIE = "MirabeauCookie";

        #endregion Protected consts

        #region Protected vars

        protected readonly IMapper _mapper;

        protected int CookieExpirationInMinutes => Convert.ToInt32(ConfigurationManagerHelper.CookieExpirationInMinutes);

        #endregion Protected vars

        #region Ctors

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion Ctors

        #region Protected methods

        protected System.Web.HttpCookie CreateCookie(string cookieName, string cookieValue, int cookieExpires)
        {
            var cookie = new System.Web.HttpCookie(cookieName, cookieValue) { Expires = DateTime.Now.AddMinutes(cookieExpires) };

            Response.Cookies.Add(cookie);

            return cookie;
        }

        protected void RemoveCookies(params string[] cookieNames)
        {
            for (int i = 0; i < cookieNames.Length; i++)
            {
                Response.Cookies.Add(new System.Web.HttpCookie(cookieNames[i])
                {
                    Expires = DateTime.Now.AddDays(-1)
                });
            }
        }

        #endregion Protected methods

        #region Events

        protected override void Initialize(RequestContext requestContext)
        {
            var userCookie = requestContext.HttpContext.Request.Cookies[USERCOOKIE];

            if (userCookie != null)
            {
                var _usuario = userCookie.Value;
                var identity = new GenericIdentity(_usuario);
                Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
                requestContext.HttpContext.User = Thread.CurrentPrincipal;
            }

            base.Initialize(requestContext);
        }

        #endregion Events
    }
}