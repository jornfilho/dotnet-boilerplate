using System;

namespace Boilerplate.Contracts.V1.Responses
{
    public class HealthCheck
    {
        public string Status { get; set; }

        public string Component { get; set; }

        public string Description { get; set; }
        
        public TimeSpan IndividualDuration { get; set; }
    }
}