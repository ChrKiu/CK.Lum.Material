using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Data.RavenDb
{
    public interface IRavenDbConfiguration
    {
        public string RavenDbName { get; }
        public IEnumerable<RavenDbCluster> RavenDbClusters { get; }
    }
}
