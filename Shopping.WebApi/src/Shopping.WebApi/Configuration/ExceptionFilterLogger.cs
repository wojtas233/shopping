using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.WebApi.Configuration
{
    public class ExceptionFilterLogger : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ExceptionFilterLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ExceptionFilterLogger");
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(), context.Exception, string.Empty);
            base.OnException(context);
        }
    }
}
