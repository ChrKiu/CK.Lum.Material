using CK.Lum.Material.Data.RavenDb;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CK.Lum.Material.Api.Configurations
{
    ///<inheritdoc/>
    public class RavenDbConfiguration : IRavenDbConfiguration
    {
        public string RavenDbName { get; private set; }
        public IEnumerable<RavenDbCluster> RavenDbClusters { get; private set; }

        public RavenDbConfiguration(IConfiguration configuration)
        {
            var name = configuration["Databases:RavenDb:Name"];

            SetUpClusters(configuration);
            
            RavenDbName = name;
        }

        private void SetUpClusters(IConfiguration configuration)
        {
            var clusters = new List<RavenDbCluster>();

            var url = configuration["Databases:RavenDb:URL"];
            var dbInstance = new RavenDbCluster { Url = url };
            clusters.Add(dbInstance);

            RavenDbClusters = clusters;
        }
    }
}
