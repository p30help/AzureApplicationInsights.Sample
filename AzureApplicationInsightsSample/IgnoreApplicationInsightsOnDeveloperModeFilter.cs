using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureApplicationInsightsSample
{
    public class IgnoreApplicationInsightsOnDeveloperModeFilter : ITelemetryProcessor
    {
        private ITelemetryProcessor Next { get; set; }

        public IgnoreApplicationInsightsOnDeveloperModeFilter(ITelemetryProcessor next)
        {
            Next = next;
        }

        public void Process(ITelemetry item)
        {
            var req = item as RequestTelemetry;

            if (req?.Properties["DeveloperMode"] == "true")
            {
                return;
            }

            Next.Process(item);
        }
    }
}

