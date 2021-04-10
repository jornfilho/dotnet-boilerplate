using System;
using System.Collections.Generic;

namespace Boilerplate.Contracts.V1.Responses
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }

        public IEnumerable<HealthCheck> Checks { get; set; }

        public TimeSpan TotalDuration { get; set; }
    }
}