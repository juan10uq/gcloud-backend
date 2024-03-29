﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using GCloud.Common.Contract;
using GCloud.WebApi.Common.Contract;
using log4net;

namespace GCloud.WebApi.Common
{
    public class ActionExceptionHandler : IActionExceptionHandler
    {
        public const int MaxStatusDescriptionLength = 512;

        private readonly ILog _logger;
        private readonly IExceptionMessageFormatter _exceptionMessageFormatter;

        public bool ExceptionHandled { get; private set; }

        public ActionExceptionHandler(ILog logger, IExceptionMessageFormatter exceptionMessageFormatter)
        {
            _logger = logger;
            _exceptionMessageFormatter = exceptionMessageFormatter;
        }

        public void HandleException(HttpActionExecutedContext filterContext)
        {
            var exception = filterContext.Exception;
            if (exception == null) return;

            ExceptionHandled = true;

            _logger.Error("Exception occured:", exception);

            var reasonPhrase = _exceptionMessageFormatter.GetEntireExceptionStack(exception);
            if (reasonPhrase.Length > MaxStatusDescriptionLength)
            {
                reasonPhrase = reasonPhrase.Substring(0, MaxStatusDescriptionLength);
            }

            reasonPhrase = reasonPhrase.Replace(Environment.NewLine, " ");

            filterContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = reasonPhrase
            };
        }
    }
}
