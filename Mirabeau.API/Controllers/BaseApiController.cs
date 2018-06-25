﻿using AutoMapper;
using Mirabeau.Domain.Interfaces.Notifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Mirabeau.API.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Protected vars

        protected readonly IMapper _mapper;
        protected IDomainNotificationHandler _notification { get; set; }

        #endregion Protected vars

        #region Ctors

        public BaseApiController(IMapper mapper, IDomainNotificationHandler notification)
        {
            _mapper = mapper;
            _notification = notification;
        }

        #endregion Ctors
    }
}