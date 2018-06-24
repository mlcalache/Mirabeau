using AutoMapper;
using Mirabeau.Domain.Interfaces.Notifications;
using Mirabeau.Infra.CrossCutting.Helpers;
using Mirabeau.UI.MVC.Enums;
using Mirabeau.UI.MVC.Models;
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

        protected const int PADRAO_TIMEOUT_TOAST = 3000;
        protected const string USERCOOKIE = "MirabeauCookie";
        private const string TOASTR = "Toastr";

        #endregion Protected consts

        #region Protected vars

        protected readonly IMapper _mapper;
        protected int CookieExpirationInMinutes => Convert.ToInt32(ConfigurationManagerHelper.CookieExpirationInMinutes);
        protected IDomainNotificationHandler _notification { get; set; }

        #endregion Protected vars

        #region Ctors

        public BaseController(IMapper mapper, IDomainNotificationHandler notification)
        {
            _mapper = mapper;
            _notification = notification;
        }

        #endregion Ctors

        #region Protected methods

        protected ToastMessageViewModel AddToastDangerMessage(string message, int timeout = PADRAO_TIMEOUT_TOAST)
        {
            var toastr = TempData[TOASTR] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(message, ToastTypeEnum.Danger, timeout);
            TempData[TOASTR] = toastr;

            return toastMessage;
        }

        protected ToastMessageViewModel AddToastInfoMessage(string message, int timeout = PADRAO_TIMEOUT_TOAST)
        {
            var toastr = TempData[TOASTR] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(message, ToastTypeEnum.Info, timeout);
            TempData[TOASTR] = toastr;

            return toastMessage;
        }

        protected ToastMessageViewModel AddToastSuccessMessage(string message, int timeout = PADRAO_TIMEOUT_TOAST)
        {
            var toastr = TempData[TOASTR] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(message, ToastTypeEnum.Success, timeout);
            TempData[TOASTR] = toastr;

            return toastMessage;
        }

        protected ToastMessageViewModel AddToastWarningMessage(string message, int timeout = PADRAO_TIMEOUT_TOAST)
        {
            var toastr = TempData[TOASTR] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(message, ToastTypeEnum.Warning, timeout);
            TempData[TOASTR] = toastr;

            return toastMessage;
        }

        protected System.Web.HttpCookie CreateCookie(string cookieName, string cookieValue, int cookieExpires)
        {
            var cookie = new System.Web.HttpCookie(cookieName, cookieValue) { Expires = DateTime.Now.AddMinutes(cookieExpires) };

            Response.Cookies.Add(cookie);

            return cookie;
        }

        protected bool HasDomainNotifications(AddErrorsOnEnum addErrorsOn = AddErrorsOnEnum.ModelError)
        {
            if (_notification.HasNotifications)
            {
                foreach (var error in _notification.GetNotifications())
                {
                    if (addErrorsOn == AddErrorsOnEnum.ModelError)
                    {
                        ModelState.AddModelError(string.Empty, error.Value);
                    }
                    else
                    {
                        AddToastDangerMessage(error.Value);
                    }
                }

                return true;
            }

            return false;
        }

        protected bool HasValidationErros(AddErrorsOnEnum addErrorsOn = AddErrorsOnEnum.ModelError)
        {
            if (_notification.HasNotifications)
            {
                foreach (var erro in _notification.GetNotifications())
                {
                    if (addErrorsOn == AddErrorsOnEnum.ModelError)
                    {
                        ModelState.AddModelError(string.Empty, erro.Value);
                    }
                    else
                    {
                        AddToastDangerMessage(erro.Value);
                    }
                }

                return true;
            }

            return false;
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