using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.Net.Http;

namespace ExampleService.Customer.Api.Helpers
{
    public class TrackDependencyResponse : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var dependencyTelemetry = telemetry as DependencyTelemetry;

            if (dependencyTelemetry == null)
                return;

            if (dependencyTelemetry.TryGetOperationDetail("HttpResponse", out var responseObj))
            {
                var responseMessage = responseObj as HttpResponseMessage;
                if(responseMessage != null)
                {
                    string stringResponseMessage = responseObj.ToString();
                    var stringResponseBody = responseMessage.Content.ReadAsStringAsync().Result;

                    dependencyTelemetry.Properties["ResponseMessage"] = stringResponseMessage;
                    dependencyTelemetry.Properties["ResponseBody"] = stringResponseBody;
                }
            }
        }
    }
}
