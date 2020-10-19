using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace basket.TelemetryInitializers
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
            //var user = (User)_httpContextAccessor.HttpContext?.Items["User"];

            //if(user != null)
            //{
            //    telemetry.Context.User.Id = user.Id.ToString();
            //}
        }
    }
}
