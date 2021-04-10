using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using Newtonsoft.Json;

namespace Boilerplate.HealthChecks
{
    public class MongoDbHealthCheck : IHealthCheck
    {
        private readonly IMongoClient _connectionMultiplexer;

        public MongoDbHealthCheck(IMongoClient connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                if (_connectionMultiplexer.Cluster.Description.State != ClusterState.Disconnected)
                    return Task.FromResult(HealthCheckResult.Healthy());

                var messages = _connectionMultiplexer.Cluster.Description.Servers.Select(x => new
                    {
                        x.ServerId, x.HeartbeatException, x.HeartbeatInterval, x.LastHeartbeatTimestamp
                    }).ToList();
                return Task.FromResult(HealthCheckResult.Unhealthy(JsonConvert.SerializeObject(messages)));

            }
            catch (Exception exception)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(exception.Message));
            }
        }
    }
}