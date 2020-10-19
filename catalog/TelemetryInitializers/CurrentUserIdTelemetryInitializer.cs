using System;
using System.Web;
using catalog.Entities;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace catalog.TelemetryInitializers
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
            var user = (User)_httpContextAccessor.HttpContext?.Items["User"];

            if(user != null)
            {
                telemetry.Context.User.Id = user.Id.ToString();
            }
        }
    }
}
