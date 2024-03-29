﻿using System.Web.Http.Controllers;
using GCloud.WebApi.Common.Contract;
using log4net;

namespace GCloud.WebApi.Common
{
    public class ActionLogHelper : IActionLogHelper
    {
        public const string EnteringText = "ENTERING";
        public const string ExitingText = "EXITING";
        public const string LogTextFormatString = "{0} {1}::{2}";

        private readonly ILog _logger;

        public ActionLogHelper(ILog logger)
        {
            _logger = logger;
        }

        public void LogEntry(HttpActionDescriptor actionDescriptor)
        {
            LogAction(actionDescriptor, EnteringText);
        }

        public void LogExit(HttpActionDescriptor actionDescriptor)
        {
            LogAction(actionDescriptor, ExitingText);
        }

        public virtual void LogAction(HttpActionDescriptor actionDescriptor, string prefix)
        {
            _logger.DebugFormat(
                LogTextFormatString,
                prefix,
                actionDescriptor.ControllerDescriptor.ControllerType.FullName,
                actionDescriptor.ActionName);
        }
    }
}
