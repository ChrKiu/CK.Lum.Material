using System.Collections.Generic;

namespace CK.Lum.Material.Data.RavenDb
{
    /// <summary>
    /// The configuration file for the RavenDb-Connection.
    /// Contains the <paramref name="RavenDbName"/> of the DB 
    /// And a list of <paramref name="RavenDbClusters"/>
    /// </summary>
    public interface IRavenDbConfiguration
    {
        public string RavenDbName { get; }
        public IEnumerable<RavenDbCluster> RavenDbClusters { get; }
    }
}
