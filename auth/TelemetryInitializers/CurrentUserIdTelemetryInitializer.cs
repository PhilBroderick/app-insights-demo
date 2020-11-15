using System;
using System.Web;
using auth.Entities;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace auth.TelemetryInitializers
{
    public class CurrentUserIdTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserIdTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Initialize(ITelemetry telemetry)
        {
            var userId = _httpContextAccessor?.HttpContext?.User.Identity.Name;
            if (userId != null)
            {
                telemetry.Context.User.Id = userId;
            }
        }
    }
}
